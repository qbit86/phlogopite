using System;
using System.Buffers;
using System.IO;
using System.Text;

namespace Phlogopite
{
    public sealed class ConsoleSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>,
        IFormattedSink<NamedProperty>
    {
        private static readonly ConsoleColor[] s_levelColorMap = new ConsoleColor[]
        {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.Yellow,
            ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Cyan
        };

        private readonly Level _minimumLevel;
        private readonly IFormatProvider _formatProvider;
        private readonly TextWriter _output;
        private readonly IFormatter<NamedProperty> _formatter = Formatter.Default;

        public ConsoleSink() : this(Level.Verbose, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel) : this(minimumLevel, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
            _output = Console.Out;
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

            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                StringBuilder sb = StringBuilderCache.Acquire();
                _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                    sb, default, default, default);
                int length = sb.Length;
                char[] buffer = ArrayPool<char>.Shared.Rent(length);
                sb.CopyTo(0, buffer, 0, length);
                StringBuilderCache.Release(sb);
                _output.WriteLine(buffer, 0, length);
                ArrayPool<char>.Shared.Return(buffer);
            }
            finally
            {
                Console.ForegroundColor = oldColor;
            }
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            Write(level, text, userProperties, writerProperties, default);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            Write(level, text, properties, default, default);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> writerProperties,
            ReadOnlySpan<NamedProperty> mediatorProperties, ArraySegment<char> formattedMessage, ReadOnlySpan<Segment> userSegments,
            ReadOnlySpan<Segment> writerSegments, ReadOnlySpan<Segment> mediatorSegments)
        {
            if (!IsEnabled(level))
                return;

            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                _output.WriteLine(formattedMessage.Array, formattedMessage.Offset, formattedMessage.Count);
            }
            finally
            {
                Console.ForegroundColor = oldColor;
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
    }
}
