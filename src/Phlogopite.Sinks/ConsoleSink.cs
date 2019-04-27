using System;
using System.IO;

namespace Phlogopite
{
    public sealed class ConsoleSink : ISink<Property>
    {
        private static readonly ConsoleColor[] s_levelColorMap = new ConsoleColor[] {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.Yellow,
            ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Cyan };

        private readonly Level _minimumLevel;

        public ConsoleSink(Level minimumLevel)
        {
            _minimumLevel = minimumLevel;
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<Property> userProperties,
            ReadOnlySpan<Property> writerProperties, ReadOnlySpan<Property> mediatorProperties)
        {
            if (!IsEnabled(level))
                return;

            TextWriter output = Console.Out;
            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                RenderLevel(level, output);
                output.Write(" ");
            }
            finally
            {
                Console.ForegroundColor = oldColor;
            }

            output.WriteLine();
        }

        private static void RenderLevel(Level level, TextWriter output)
        {
            if (output is null || output == TextWriter.Null)
                return;

            switch (level)
            {
                case Level.Verbose:
                    output.Write("V");
                    break;
                case Level.Debug:
                    output.Write("D");
                    break;
                case Level.Info:
                    output.Write("I");
                    break;
                case Level.Warning:
                    output.Write("W");
                    break;
                case Level.Error:
                    output.Write("E");
                    break;
                case Level.Fatal:
                    output.Write("F");
                    break;
                case Level.Silent:
                    output.Write("S");
                    break;
                default:
                    output.Write("-");
                    break;
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
