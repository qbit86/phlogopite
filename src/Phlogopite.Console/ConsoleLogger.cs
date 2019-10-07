using System;
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using Phlogopite.Internal;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Phlogopite
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public sealed class ConsoleLogger : ILogger<NamedProperty>
    {
        internal const bool DefaultEmitLevel = false;
        internal const bool DefaultEmitTime = false;
        internal const bool DefaultIsSynchronized = false;
        internal const Level DefaultMinimumLevel = Level.Verbose;

        internal static readonly CultureInfo DefaultFormatProvider = CultureConstants.FixedCulture;
        internal static readonly PropertyFormatter DefaultPropertyFormatter = PropertyFormatter.Default;

        private static readonly object s_syncRoot = new object();

        private readonly bool _emitLevel;
        private readonly bool _emitTime;
        private readonly IFormatProvider _formatProvider;
        private readonly bool _isSynchronized;
        private readonly Level _minimumLevel;
        private readonly IPropertyFormatter<NamedProperty> _propertyFormatter;
        private readonly Level? _standardErrorMinimumLevel;

        public ConsoleLogger() : this(DefaultMinimumLevel, null, DefaultIsSynchronized, DefaultEmitLevel,
            DefaultEmitTime, DefaultPropertyFormatter, DefaultFormatProvider) { }

        public ConsoleLogger(Level minimumLevel) : this(minimumLevel, null, DefaultIsSynchronized, DefaultEmitLevel,
            DefaultEmitTime, DefaultPropertyFormatter, DefaultFormatProvider) { }

        public ConsoleLogger(Level minimumLevel, IFormatProvider formatProvider) : this(minimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultPropertyFormatter, formatProvider) { }

        internal ConsoleLogger(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized,
            bool emitLevel, bool emitTime,
            IPropertyFormatter<NamedProperty> propertyFormatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _standardErrorMinimumLevel = standardErrorMinimumLevel;
            _isSynchronized = isSynchronized;
            _emitLevel = emitLevel;
            _emitTime = emitTime;
            _propertyFormatter = propertyFormatter ?? DefaultPropertyFormatter;
            _formatProvider = formatProvider ?? DefaultFormatProvider;
        }

        public static ConsoleLogger Default { get; } = new ConsoleLogger();

        public int MaxAttachedPropertyCount => 0;

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            WriteWhenNoFormattedProperties(level, text, userProperties, attachedProperties);
        }

        private void WriteWhenNoFormattedProperties(Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> attachedProperties)
        {
            int totalCapacity = FormattingHelpers.EstimateCapacity(text, userProperties, attachedProperties);
            var vsb = new ValueStringBuilder(totalCapacity);
            try
            {
                AppendWhenNoFormattedProperties(level, text, userProperties, attachedProperties, ref vsb);
                WriteLineThenFlush(level, vsb.UnsafeArray, 0, vsb.Length);
            }
            finally
            {
                vsb.Dispose();
            }
        }

        private void AppendWhenNoFormattedProperties(Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> attachedProperties,
            ref ValueStringBuilder vsb)
        {
            if (_emitLevel)
            {
                ReadOnlySpan<char> levelChars = "VDIWEA-".AsSpan();
                char levelChar = (uint)level < (uint)levelChars.Length ? levelChars[(int)level] : '-';
                vsb.Append(levelChar);
            }

            int capacity = FormattingHelpers.EstimateCapacity(userProperties);
            StringBuilder sb = StringBuilderCache.Acquire(capacity);
            Range[] ranges = ArrayPool<Range>.Shared.Rent(userProperties.Length + attachedProperties.Length);
            try
            {
                var userRanges = new Span<Range>(ranges, 0, userProperties.Length);
                var attachedRanges = new Span<Range>(ranges, userProperties.Length, attachedProperties.Length);
                _propertyFormatter.Format(userProperties, attachedProperties,
                    sb, userRanges, attachedRanges, _formatProvider);

                if (_emitTime)
                {
                    int timeIndex = FindByName(attachedProperties, KnownProperties.Time);
                    if (timeIndex >= 0 && timeIndex < attachedRanges.Length)
                    {
                        if (vsb.Length > 0)
                            vsb.Append(' ');

                        Range timeRange = attachedRanges[timeIndex];
                        int timeLength = timeRange.Length;
                        int destinationIndex = vsb.Length;
                        Span<char> _ = vsb.AppendSpan(timeLength);
                        sb.CopyTo(timeRange.Start, vsb.UnsafeArray, destinationIndex, timeLength);
                    }
                }

                FindString(attachedProperties, KnownProperties.Category, out string category);
                FindString(attachedProperties, KnownProperties.Source, out string source);
                if (category != null || source != null)
                {
                    if (vsb.Length > 0)
                        vsb.Append(' ');

                    vsb.Append('[');
                    if (!string.IsNullOrEmpty(category))
                        vsb.Append(category);

                    if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(source))
                        vsb.Append('.');

                    if (!string.IsNullOrEmpty(source))
                        vsb.Append(source);

                    vsb.Append(']');
                }

                if (!string.IsNullOrEmpty(text))
                {
                    if (vsb.Length > 0)
                        vsb.Append(' ');

                    vsb.Append(text);
                }

                for (int i = 0; i != userProperties.Length; ++i)
                {
                    // Chose separator.
                    if (i == 0)
                    {
                        if (string.IsNullOrEmpty(text))
                        {
                            if (vsb.Length > 0)
                                vsb.Append(' ');
                        }
                        else
                        {
                            if (char.IsPunctuation(text[text.Length - 1]))
                                vsb.Append(' ');
                            else if (string.IsNullOrEmpty(userProperties[0].Name))
                                vsb.Append(": ");
                            else
                                vsb.Append(". ");
                        }

                        // Check, if default property formatter.
                        if (ReferenceEquals(_propertyFormatter, PropertyFormatter.Default))
                        {
                            int destinationIndex = vsb.Length;
                            int propertyLength = userRanges[userRanges.Length - 1].End - userRanges[0].Start;
                            if (propertyLength > 0)
                            {
                                Span<char> _ = vsb.AppendSpan(propertyLength);
                                sb.CopyTo(userRanges[0].Start, vsb.UnsafeArray, destinationIndex, propertyLength);
                            }

                            break;
                        }
                    }
                    else
                    {
                        vsb.Append(", ");
                    }

                    if (!string.IsNullOrEmpty(userProperties[i].Name))
                    {
                        vsb.Append(userProperties[i].Name);
                        vsb.Append(": ");
                    }

                    if (i < userRanges.Length)
                    {
                        Range propertyRange = userRanges[i];
                        int propertyLength = propertyRange.Length;
                        if (propertyLength > 0)
                        {
                            int destinationIndex = vsb.Length;
                            Span<char> _ = vsb.AppendSpan(propertyLength);
                            sb.CopyTo(propertyRange.Start, vsb.UnsafeArray, destinationIndex, propertyLength);
                        }
                    }
                }
            }
            finally
            {
                ArrayPool<Range>.Shared.Return(ranges);
                StringBuilderCache.Release(sb);
            }
        }

        private static int FindByName(ReadOnlySpan<NamedProperty> properties, string name)
        {
            for (int i = 0; i != properties.Length; ++i)
            {
                if (string.Equals(properties[i].Name, name, StringComparison.Ordinal))
                    return i;
            }

            return -1;
        }

        private static void FindString(ReadOnlySpan<NamedProperty> properties, string name, out string value)
        {
            for (int i = 0; i != properties.Length; ++i)
            {
                NamedProperty p = properties[i];

                if (!ReferenceEquals(p.Name, name))
                    continue;

                if (p.TryGetString(out value))
                    return;
            }

            value = default;
        }

        private TextWriter SelectOutputStream(Level level)
        {
            if (!_standardErrorMinimumLevel.HasValue)
                return Console.Out;

            return level < _standardErrorMinimumLevel.GetValueOrDefault() ? Console.Out : Console.Error;
        }

        private void WriteLineThenFlush(Level level, char[] buffer, int index, int count)
        {
            if (!_isSynchronized)
            {
                WriteLineThenFlushUnsynchronized(level, buffer, index, count);
                return;
            }

            lock (s_syncRoot)
            {
                WriteLineThenFlushUnsynchronized(level, buffer, index, count);
            }
        }

        private void WriteLineThenFlushUnsynchronized(Level level, char[] buffer, int index, int count)
        {
            Debug.Assert(buffer != null);

            ConsoleColor oldColor = ConsoleHelpers.SetForegroundColor(level);
            try
            {
                TextWriter output = SelectOutputStream(level);

                output.WriteLine(buffer, index, count);
                output.Flush();
            }
            finally
            {
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
