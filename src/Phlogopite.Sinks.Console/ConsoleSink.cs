using System;
using System.Buffers;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Phlogopite.Sinks
{
    public sealed class ConsoleSink : ISink<NamedProperty>,
        IFormattedSink<NamedProperty>
    {
        private static readonly ConsoleColor[] s_levelColorMap =
        {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.Red,
            ConsoleColor.DarkRed, ConsoleColor.Cyan
        };

        private static readonly string[] s_levelPrefixMap = { "V ", "D ", "I ", "W ", "E ", "A ", "- " };

        private static readonly object s_syncRoot = new object();

        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly bool _isSynchronized;
        private readonly Level _minimumLevel;
        private readonly bool _omitLevel;
        private readonly bool _omitTime;
        private readonly Level? _standardErrorMinimumLevel;

        public ConsoleSink() : this(Level.Verbose, null, false, false, false,
            Formatter.Default, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel) :
            this(minimumLevel, null, false, false, false, Formatter.Default, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, IFormatProvider formatProvider) :
            this(minimumLevel, null, false, false, false, Formatter.Default, formatProvider) { }

        internal ConsoleSink(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized,
            bool omitLevel, bool omitTime,
            IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _standardErrorMinimumLevel = standardErrorMinimumLevel;
            _isSynchronized = isSynchronized;
            _omitLevel = omitLevel;
            _omitTime = omitTime;
            _formatter = formatter ?? Formatter.Default;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage, ReadOnlySpan<Range> userSegments,
            ReadOnlySpan<Range> writerSegments, ReadOnlySpan<Range> mediatorSegments)
        {
            if (!IsEnabled(level))
                return;

            if (formattedMessage.Array is null)
                return;

            if (!_omitLevel && !_omitTime)
            {
                WriteLineThenFlush(level, formattedMessage.Array, formattedMessage.Offset, formattedMessage.Count);
                return;
            }

            if (!_omitTime)
            {
                Debug.Assert(_omitLevel, nameof(_omitLevel));
                WriteLineThenFlush(level, formattedMessage.Array,
                    formattedMessage.Offset + 2, formattedMessage.Count - 2);
                return;
            }

            Debug.Assert(_omitTime, nameof(_omitTime));
            int timeIndex = FindByName(mediatorProperties, "time");
            if ((uint)timeIndex >= (uint)mediatorSegments.Length)
            {
                if (!_omitLevel)
                {
                    WriteLineThenFlush(level, formattedMessage.Array, formattedMessage.Offset, formattedMessage.Count);
                    return;
                }

                Debug.Assert(_omitLevel, nameof(_omitLevel));
                WriteLineThenFlush(level, formattedMessage.Array,
                    formattedMessage.Offset + 2, formattedMessage.Count - 2);
                return;
            }

            Debug.Assert((uint)timeIndex < (uint)mediatorSegments.Length);
            Range range = mediatorSegments[timeIndex];
            int startIndex = range.End + 1;
            var buffer = new ArraySegment<char>(formattedMessage.Array,
                formattedMessage.Offset + startIndex, formattedMessage.Count - startIndex);

            WriteLineThenFlush(level, buffer.Array, buffer.Offset, buffer.Count, !_omitLevel);
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            int capacity = FormattingHelpers.EstimateCapacity(text, userProperties, writerProperties);
            StringBuilder sb = StringBuilderCache.Acquire(capacity);
            _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                sb, default, default, default);
            int length = sb.Length;
            char[] buffer = ArrayPool<char>.Shared.Rent(length);
            sb.CopyTo(0, buffer, 0, length);
            StringBuilderCache.Release(sb);
            WriteLineThenFlush(level, buffer, 0, length);
            ArrayPool<char>.Shared.Return(buffer);
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
            Debug.Assert(buffer != null);

            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                TextWriter output = SelectOutputStream(level);

                if (!_isSynchronized)
                {
                    if (prependLevel)
                        output.Write(GetLevelPrefix(level));

                    output.WriteLine(buffer, index, count);
                    output.Flush();
                    return;
                }

                lock (s_syncRoot)
                {
                    if (prependLevel)
                        output.Write(GetLevelPrefix(level));

                    output.WriteLine(buffer, index, count);
                    output.Flush();
                }
            }
            finally
            {
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
