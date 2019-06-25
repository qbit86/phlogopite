using System;
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace Phlogopite.Sinks
{
    public sealed class ConsoleSink : ISink<NamedProperty>, IFormattedSink<NamedProperty>
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
        private readonly Level? _standardErrorMinimumLevel;

        public ConsoleSink() : this(DefaultMinimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultFormatter, DefaultFormatProvider) { }

        public ConsoleSink(Level minimumLevel) : this(minimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultFormatter, DefaultFormatProvider) { }

        public ConsoleSink(Level minimumLevel, IFormatProvider formatProvider) : this(minimumLevel, null,
            DefaultIsSynchronized, DefaultEmitLevel, DefaultEmitTime, DefaultFormatter, formatProvider) { }

        internal ConsoleSink(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized,
            bool emitLevel, bool emitTime,
            IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _standardErrorMinimumLevel = standardErrorMinimumLevel;
            _isSynchronized = isSynchronized;
            _emitLevel = emitLevel;
            _emitTime = emitTime;
            _formatter = formatter ?? DefaultFormatter;
            _formatProvider = formatProvider ?? DefaultFormatProvider;
        }

        public static ConsoleSink Default { get; } = new ConsoleSink();

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage, ReadOnlySpan<Range> userRanges,
            ReadOnlySpan<Range> writerRanges, ReadOnlySpan<Range> mediatorRanges)
        {
            if (!IsEnabled(level))
                return;

            if (formattedMessage.Array is null)
                return;

            if (_emitLevel && _emitTime)
            {
                WriteLineThenFlush(level, formattedMessage.Array, formattedMessage.Offset, formattedMessage.Count);
                return;
            }

            const int levelLength = 2;
            if (_emitTime)
            {
                Debug.Assert(!_emitLevel, "!_emitLevel");
                if (formattedMessage.Count > levelLength)
                {
                    WriteLineThenFlush(level, formattedMessage.Array,
                        formattedMessage.Offset + levelLength, formattedMessage.Count - levelLength);
                }

                return;
            }

            Debug.Assert(!_emitTime, "!_emitTime");
            int timeIndex = FindByName(mediatorProperties, "time");
            if ((uint)timeIndex >= (uint)mediatorRanges.Length)
            {
                if (_emitLevel)
                {
                    WriteLineThenFlush(level, formattedMessage.Array, formattedMessage.Offset, formattedMessage.Count);
                    return;
                }

                Debug.Assert(!_emitLevel, "!_emitLevel");
                if (formattedMessage.Count > levelLength)
                {
                    WriteLineThenFlush(level, formattedMessage.Array,
                        formattedMessage.Offset + levelLength, formattedMessage.Count - levelLength);
                }

                return;
            }

            Debug.Assert((uint)timeIndex < (uint)mediatorRanges.Length);
            Range range = mediatorRanges[timeIndex];
            int startIndex = range.End + 1;
            if (startIndex < (uint)formattedMessage.Count)
            {
                var buffer = new ArraySegment<char>(formattedMessage.Array,
                    formattedMessage.Offset + startIndex, formattedMessage.Count - startIndex);

                WriteLineThenFlush(level, buffer.Array, buffer.Offset, buffer.Count, _emitLevel);
            }
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
            char[] buffer = null;
            try
            {
                Span<Range> mediatorRanges = stackalloc Range[mediatorProperties.Length];
                _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                    sb, default, default, mediatorRanges);

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
                int timeIndex = FindByName(mediatorProperties, "time");
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
