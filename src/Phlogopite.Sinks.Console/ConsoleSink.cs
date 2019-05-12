using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Phlogopite.Sinks
{
    public sealed class ConsoleSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>,
        IFormattedSink<NamedProperty>
    {
        private static readonly ConsoleColor[] s_levelColorMap =
        {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.Yellow,
            ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Cyan
        };

        private static readonly object s_syncRoot = new object();

        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly bool _isSynchronized;
        private readonly Level _minimumLevel;
        private readonly Level? _standardErrorMinimumLevel;

        public ConsoleSink() : this(Level.Verbose, null, false, Formatter.Default, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel) :
            this(minimumLevel, null, false, Formatter.Default, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, Level? standardErrorMinimumLevel) :
            this(minimumLevel, standardErrorMinimumLevel, false, Formatter.Default, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized) :
            this(minimumLevel, standardErrorMinimumLevel, isSynchronized,
                Formatter.Default, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized,
            IFormatter<NamedProperty> formatter) :
            this(minimumLevel, standardErrorMinimumLevel, isSynchronized, formatter, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, Level? standardErrorMinimumLevel, bool isSynchronized,
            IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _standardErrorMinimumLevel = standardErrorMinimumLevel;
            _isSynchronized = isSynchronized;
            _formatter = formatter ?? Formatter.Default;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage, ReadOnlySpan<Segment> userSegments,
            ReadOnlySpan<Segment> writerSegments, ReadOnlySpan<Segment> mediatorSegments)
        {
            if (!IsEnabled(level))
                return;

            if (formattedMessage.Array is null)
                return;

            WriteLineThenFlush(level, formattedMessage.Array, formattedMessage.Offset, formattedMessage.Count);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            Write(level, text, userProperties, writerProperties, default);
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            if (!IsEnabled(level))
                return;

            StringBuilder sb = StringBuilderCache.Acquire();
            _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                sb, default, default, default);
            int length = sb.Length;
            char[] buffer = ArrayPool<char>.Shared.Rent(length);
            sb.CopyTo(0, buffer, 0, length);
            StringBuilderCache.Release(sb);
            WriteLineThenFlush(level, buffer, 0, length);
            ArrayPool<char>.Shared.Return(buffer);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            Write(level, text, properties, default, default);
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

        private TextWriter SelectOutputStream(Level level)
        {
            if (!_standardErrorMinimumLevel.HasValue)
                return Console.Out;

            return level < _standardErrorMinimumLevel.Value ? Console.Out : Console.Error;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteLineThenFlush(Level level, char[] buffer, int index, int count)
        {
            Debug.Assert(buffer != null);

            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                TextWriter output = SelectOutputStream(level);

                if (!_isSynchronized)
                {
                    output.WriteLine(buffer, index, count);
                    output.Flush();
                    return;
                }

                lock (s_syncRoot)
                {
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
