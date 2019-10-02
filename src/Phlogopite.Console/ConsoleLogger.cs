﻿using System;
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
        internal static readonly Formatter DefaultFormatter = Formatter.Default;

        private static readonly ConsoleColor[] s_levelColorMap =
        {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.Red,
            ConsoleColor.DarkRed, ConsoleColor.Cyan
        };

        private static readonly string[] s_levelPrefixMap = { "V ", "D ", "I ", "W ", "E ", "A ", "- " };
        private static readonly object s_syncRoot = new object();

        private readonly bool _emitLevel;
        private readonly bool _emitTime;
        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly bool _isSynchronized;
        private readonly Level _minimumLevel;
        private readonly IPropertiesFormatter<NamedProperty> _propertiesFormatter;
        private readonly Level? _standardErrorMinimumLevel;

        public ConsoleLogger() : this(DefaultMinimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultFormatter, DefaultFormatProvider) { }

        public ConsoleLogger(Level minimumLevel) : this(minimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultFormatter, DefaultFormatProvider) { }

        public ConsoleLogger(Level minimumLevel, IFormatProvider formatProvider) : this(minimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultFormatter, formatProvider) { }

        internal ConsoleLogger(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized,
            bool emitLevel, bool emitTime,
            IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _standardErrorMinimumLevel = standardErrorMinimumLevel;
            _isSynchronized = isSynchronized;
            _emitLevel = emitLevel;
            _emitTime = emitTime;
            _formatter = formatter ?? DefaultFormatter;
            _propertiesFormatter = PropertiesFormatter.Default;
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
            // TODO: Add check if need to handle non-default formatter.
            // DO NOT COMMIT!!!
            if (ReferenceEquals(_formatter, DefaultFormatter))
                WriteWithDefaultFormatter(level, text, userProperties, attachedProperties);
            else
                WriteWithCustomPropertiesFormatter(level, text, userProperties, attachedProperties);
        }

        private void WriteWithCustomPropertiesFormatter(Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> attachedProperties)
        {
            // TODO: Estimate initialCapacity.
            var vsb = new ValueStringBuilder(140);
            StringBuilder sb = StringBuilderCache.Acquire(140);
            Range[] ranges = ArrayPool<Range>.Shared.Rent(userProperties.Length + attachedProperties.Length);
            try
            {
                if (_emitLevel)
                {
                    ReadOnlySpan<char> levelChars = "VDIWEA-".AsSpan();
                    char levelChar = (uint)level < (uint)levelChars.Length ? levelChars[(int)level] : '-';
                    vsb.Append(levelChar);
                }

                var userRanges = new Span<Range>(ranges, 0, userProperties.Length);
                var attachedRanges = new Span<Range>(ranges, userProperties.Length, attachedProperties.Length);
                _propertiesFormatter.Format(userProperties, attachedProperties,
                    sb, userRanges, attachedRanges, _formatProvider);

                if (_emitTime)
                {
                    int timeIndex = FindByName(attachedProperties, KnownProperties.Time);
                    if (timeIndex > 0)
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

                // TODO: Check, if default property formatter.
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

                    // TODO: Replace with actual value.
                    vsb.Append('_');
                }

                WriteLineThenFlush(level, vsb.UnsafeArray, 0, vsb.Length);
            }
            finally
            {
                ArrayPool<Range>.Shared.Return(ranges);
                StringBuilderCache.Release(sb);
                vsb.Dispose();
            }
        }

        private void WriteWithDefaultFormatter(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            int capacity = FormattingHelpers.EstimateCapacity(text, userProperties, attachedProperties);
            StringBuilder sb = StringBuilderCache.Acquire(capacity);
            char[] buffer = null;
            try
            {
                Span<Range> mediatorRanges = stackalloc Range[attachedProperties.Count];
                _formatter.Format(level, text, userProperties, attachedProperties,
                    sb, default, mediatorRanges, _formatProvider);

                if (_emitLevel && _emitTime)
                {
                    int length = sb.Length;
                    buffer = ArrayPool<char>.Shared.Rent(length);
                    sb.CopyTo(0, buffer, 0, length);
                    WriteLineThenFlush(level, buffer, 0, length);
                    return;
                }

                if (_emitTime)
                {
                    Debug.Assert(!_emitLevel, "!_emitLevel");
                    const int startIndex = 2;
                    if (startIndex < (uint)sb.Length)
                    {
                        int length = sb.Length - startIndex;
                        buffer = ArrayPool<char>.Shared.Rent(length);
                        sb.CopyTo(startIndex, buffer, 0, length);
                        WriteLineThenFlush(level, buffer, 0, length);
                    }

                    return;
                }

                Debug.Assert(!_emitTime, "!_emitTime");
                int timeIndex = FindByName(attachedProperties, "time");
                if ((uint)timeIndex >= (uint)mediatorRanges.Length)
                {
                    if (_emitLevel)
                    {
                        int length = sb.Length;
                        buffer = ArrayPool<char>.Shared.Rent(length);
                        sb.CopyTo(0, buffer, 0, length);
                        WriteLineThenFlush(level, buffer, 0, length);
                        return;
                    }

                    Debug.Assert(!_emitLevel, "!_emitLevel");
                    {
                        const int startIndex = 2;
                        if (startIndex < (uint)sb.Length)
                        {
                            int length = sb.Length - startIndex;
                            buffer = ArrayPool<char>.Shared.Rent(length);
                            sb.CopyTo(startIndex, buffer, 0, length);
                            WriteLineThenFlush(level, buffer, 0, length);
                        }

                        return;
                    }
                }

                Debug.Assert((uint)timeIndex < (uint)mediatorRanges.Length);
                {
                    Range range = mediatorRanges[timeIndex];
                    int startIndex = range.End + 1;
                    if ((uint)startIndex < (uint)sb.Length)
                    {
                        int length = sb.Length - startIndex;
                        buffer = ArrayPool<char>.Shared.Rent(length);
                        sb.CopyTo(startIndex, buffer, 0, length);
                        WriteLineThenFlush(level, buffer, 0, length, _emitLevel);
                    }
                }
            }
            finally
            {
                if (buffer != null)
                    ArrayPool<char>.Shared.Return(buffer);

                StringBuilderCache.Release(sb);
            }
        }

        private static ConsoleColor SetForegroundColor(ConsoleColor color)
        {
            ConsoleColor result = Console.ForegroundColor;
            Console.ForegroundColor = color;
            return result;
        }

        private static ConsoleColor SetForegroundColor(Level level)
        {
            if (level < 0 || (int)level >= s_levelColorMap.Length)
                return Console.ForegroundColor;

            return SetForegroundColor(s_levelColorMap[(int)level]);
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

        private static int FindString(ReadOnlySpan<NamedProperty> properties, string name, out string value)
        {
            for (int i = 0; i != properties.Length; ++i)
            {
                NamedProperty p = properties[i];

                if (!ReferenceEquals(p.Name, name))
                    continue;

                if (p.TryGetString(out value))
                    return i;
            }

            value = default;
            return -1;
        }

        private static string GetLevelPrefix(Level level)
        {
            return (uint)level < (uint)s_levelPrefixMap.Length ? s_levelPrefixMap[(int)level] : "- ";
        }

        private TextWriter SelectOutputStream(Level level)
        {
            if (!_standardErrorMinimumLevel.HasValue)
                return Console.Out;

            return level < _standardErrorMinimumLevel.GetValueOrDefault() ? Console.Out : Console.Error;
        }

        private void WriteLineThenFlush(Level level, char[] buffer, int index, int count, bool prependLevel = false)
        {
            if (!_isSynchronized)
            {
                WriteLineThenFlushUnsynchronized(level, buffer, index, count, prependLevel);
                return;
            }

            lock (s_syncRoot)
            {
                WriteLineThenFlushUnsynchronized(level, buffer, index, count, prependLevel);
            }
        }

        // TODO: Refactor.
        private void WriteLineThenFlushUnsynchronized(
            Level level, char[] buffer, int index, int count, bool prependLevel)
        {
            Debug.Assert(buffer != null);

            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                TextWriter output = SelectOutputStream(level);

                if (prependLevel)
                    output.Write(GetLevelPrefix(level));

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
