using System;
using System.IO;

namespace Phlogopite
{
    public sealed class ConsoleSink : ISink<NamedProperty>
    {
        private static readonly ConsoleColor[] s_levelColorMap = new ConsoleColor[] {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.Yellow,
            ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.Cyan };

        private readonly Level _minimumLevel;
        private readonly IFormatProvider _formatProvider;

        public ConsoleSink() : this(Level.Verbose, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel) : this(minimumLevel, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
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

            TextWriter output = Console.Out;
            ConsoleColor oldColor = SetForegroundColor(level);
            try
            {
                RenderLevel(level, output);
                output.Write(" ");
                if (!mediatorProperties.IsEmpty && string.Equals(mediatorProperties[0].Name, "timestamp", StringComparison.Ordinal)
                    && mediatorProperties[0].TryGetDateTime(out DateTime timestamp))
                {
                    RenderTime(timestamp, output);
                }
                else
                {
                    output.Write("            ");
                }

                output.Write(" ");
                if (!writerProperties.IsEmpty && string.Equals(writerProperties[0].Name, "tag", StringComparison.Ordinal)
                    && writerProperties[0].TryGetString(out string tag))
                {
                    output.Write("[");
                    output.Write(tag);
                    output.Write("] ");
                }

                output.Write(text);

                for (int i = 0; i != userProperties.Length; ++i)
                {
                    if (i == 0 && !string.IsNullOrEmpty(text))
                    {
                        bool endsWithPunctuation = char.IsPunctuation(text, text.Length - 1);
                        if (endsWithPunctuation)
                        {
                            output.Write(" ");
                            if (!string.IsNullOrEmpty(userProperties[i].Name))
                            {
                                output.Write(userProperties[i].Name);
                                output.Write(": ");
                            }

                            RenderValue(userProperties[i], output);
                        }
                        else if (string.IsNullOrEmpty(userProperties[i].Name))
                        {
                            output.Write(": ");
                            RenderValue(userProperties[i], output);
                        }
                        else
                        {
                            output.Write(". ");
                            output.Write(userProperties[i].Name);
                            output.Write(": ");
                            RenderValue(userProperties[i], output);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(userProperties[i].Name))
                        {
                            output.Write(userProperties[i].Name);
                            output.Write(": ");
                        }

                        RenderValue(userProperties[i], output);
                    }

                    if (i + 1 < userProperties.Length)
                    {
                        output.Write(", ");
                    }
                }
            }
            finally
            {
                Console.ForegroundColor = oldColor;
                output.WriteLine();
            }
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
            if (timestamp.Millisecond < 10)
                output.Write("00");
            else if (timestamp.Millisecond < 100)
                output.Write("0");

            output.Write(timestamp.Millisecond);
        }

        private void RenderValue(in NamedProperty p, TextWriter output)
        {
            if (output is null || output == TextWriter.Null)
                return;

            switch (p.TypeCode)
            {
                case TypeCode.Empty:
                    return;
                case TypeCode.Object:
                    output.Write(p.AsObject);
                    return;
                case TypeCode.Boolean:
                    output.Write(p.AsBoolean);
                    return;
                case TypeCode.Char:
                    output.Write(p.AsChar);
                    return;
                case TypeCode.SByte:
                    output.Write(p.AsSByte);
                    return;
                case TypeCode.Byte:
                    output.Write(p.AsByte);
                    return;
                case TypeCode.Int16:
                    output.Write(p.AsInt16);
                    return;
                case TypeCode.UInt16:
                    output.Write(p.AsUInt16);
                    return;
                case TypeCode.Int32:
                    output.Write(p.AsInt32);
                    return;
                case TypeCode.UInt32:
                    output.Write(p.AsUInt32);
                    return;
                case TypeCode.Int64:
                    output.Write(p.AsInt64);
                    return;
                case TypeCode.UInt64:
                    output.Write(p.AsUInt64);
                    return;
                case TypeCode.Single:
                    output.Write(p.AsSingle);
                    return;
                case TypeCode.Double:
                    output.Write(p.AsDouble);
                    return;
                case TypeCode.DateTime:
                    output.Write(p.AsDateTime.ToString(_formatProvider));
                    return;
                case TypeCode.String:
                    output.Write(p.AsString);
                    return;
                default:
                    output.Write(p.AsObject);
                    return;
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
