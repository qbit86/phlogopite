using System;
using System.IO;
using static System.Diagnostics.Debug;

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
                if (!mediatorProperties.IsEmpty && string.Equals(mediatorProperties[0].Name, "timestamp")
                    && mediatorProperties[0].TryGetDateTime(out DateTime timestamp))
                {
                    RenderTime(timestamp, output);
                }
                else
                {
                    output.Write("            ");
                }

                output.Write(" ");
                if (!writerProperties.IsEmpty && string.Equals(writerProperties[0].Name, "tag")
                    && writerProperties[0].TryGetString(out string tag))
                {
                    output.Write("[");
                    output.Write(tag);
                    output.Write("] ");
                }
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

        private static void RenderTime(DateTime timestamp, TextWriter output)
        {
            if (output is null || output == TextWriter.Null)
                return;

            // timestamp.TryFormat() is not available in netstandard2.0.

            if (timestamp.Hour < 10)
                output.Write("0");

            output.Write(timestamp.Hour);
            output.Write(":");
            if (timestamp.Minute < 10)
                output.Write("0");

            output.Write(timestamp.Minute);
            output.Write(":");
            if (timestamp.Second < 10)
                output.Write("0");

            output.Write(timestamp.Second);
            output.Write(".");
            if (timestamp.Second < 10)
                output.Write("00");
            else if (timestamp.Second < 100)
                output.Write("0");

            output.Write(timestamp.Millisecond);
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
