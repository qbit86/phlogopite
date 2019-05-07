#if NET35 || NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#elif NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#elif NETCOREAPP1_0 || NETCOREAPP1_1 || NETCOREAPP2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#endif

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
        private readonly TextWriter _output;
        private readonly Renderer _renderer;

        public ConsoleSink() : this(Level.Verbose, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel) : this(minimumLevel, CultureConstants.FixedCulture) { }

        public ConsoleSink(Level minimumLevel, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
            _output = Console.Out ?? TextWriter.Null;
            _renderer = new Renderer(_output, _formatProvider);
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
                RenderLevel(level);
                _output.Write(" ");
                if (!mediatorProperties.IsEmpty
                    && string.Equals(mediatorProperties[0].Name, "timestamp", StringComparison.Ordinal)
                    && mediatorProperties[0].TryGetDateTime(out DateTime timestamp))
                {
                    RenderTime(timestamp);
                }
                else
                {
                    _output.Write("            ");
                }

                _output.Write(" ");
                if (!writerProperties.IsEmpty
                    && string.Equals(writerProperties[0].Name, "tag", StringComparison.Ordinal)
                    && writerProperties[0].TryGetString(out string tag))
                {
                    _output.Write("[");
                    _output.Write(tag);
                    _output.Write("] ");
                }

                _output.Write(text);

                for (int i = 0; i != userProperties.Length; ++i)
                {
                    if (i == 0 && !string.IsNullOrEmpty(text))
                    {
                        bool endsWithPunctuation = char.IsPunctuation(text, text.Length - 1);
                        if (endsWithPunctuation)
                        {
                            _output.Write(" ");
                            if (!string.IsNullOrEmpty(userProperties[i].Name))
                            {
                                _output.Write(userProperties[i].Name);
                                _output.Write(": ");
                            }

                            RenderValue(userProperties[i]);
                        }
                        else if (string.IsNullOrEmpty(userProperties[i].Name))
                        {
                            _output.Write(": ");
                            RenderValue(userProperties[i]);
                        }
                        else
                        {
                            _output.Write(". ");
                            _output.Write(userProperties[i].Name);
                            _output.Write(": ");
                            RenderValue(userProperties[i]);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(userProperties[i].Name))
                        {
                            _output.Write(userProperties[i].Name);
                            _output.Write(": ");
                        }

                        RenderValue(userProperties[i]);
                    }

                    if (i + 1 < userProperties.Length)
                    {
                        _output.Write(", ");
                    }
                }
            }
            finally
            {
                Console.ForegroundColor = oldColor;
                _output.WriteLine();
            }
        }

        private void RenderLevel(Level level)
        {
            switch (level)
            {
                case Level.Verbose:
                    _output.Write("V");
                    break;
                case Level.Debug:
                    _output.Write("D");
                    break;
                case Level.Info:
                    _output.Write("I");
                    break;
                case Level.Warning:
                    _output.Write("W");
                    break;
                case Level.Error:
                    _output.Write("E");
                    break;
                case Level.Assert:
                    _output.Write("A");
                    break;
                case Level.Silent:
                    _output.Write("S");
                    break;
                default:
                    _output.Write("-");
                    break;
            }
        }

        private void RenderTime(DateTime timestamp)
        {
            const string format = "HH:mm:ss.fff";
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(timestamp.ToString(format, _formatProvider));
#else
            Span<char> stackBuffer = stackalloc char[12];
            if (timestamp.TryFormat(stackBuffer, out int formattedLength, format, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = stackBuffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(timestamp.ToString(format, _formatProvider));
            }
#endif
        }

        private void RenderValue(in NamedProperty p)
        {
            switch (p.TypeCode)
            {
                case TypeCode.Empty:
                    return;
                case TypeCode.Object:
                    _output.Write(Convert.ToString(p.AsObject, _formatProvider));
                    return;
                case TypeCode.Boolean:
                    _renderer.Render(p.AsBoolean);
                    return;
                case TypeCode.Char:
                    _output.Write(p.AsChar);
                    return;
                case TypeCode.SByte:
                    _renderer.Render(p.AsSByte);
                    return;
                case TypeCode.Byte:
                    _renderer.Render(p.AsByte);
                    return;
                case TypeCode.Int16:
                    _renderer.Render(p.AsInt16);
                    return;
                case TypeCode.UInt16:
                    _renderer.Render(p.AsUInt16);
                    return;
                case TypeCode.Int32:
                    _renderer.Render(p.AsInt32);
                    return;
                case TypeCode.UInt32:
                    _renderer.Render(p.AsUInt32);
                    return;
                case TypeCode.Int64:
                    _renderer.Render(p.AsInt64);
                    return;
                case TypeCode.UInt64:
                    _renderer.Render(p.AsUInt64);
                    return;
                case TypeCode.Single:
                    _renderer.Render(p.AsSingle);
                    return;
                case TypeCode.Double:
                    _renderer.Render(p.AsDouble);
                    return;
                case TypeCode.DateTime:
                    _renderer.Render(p.AsDateTime);
                    return;
                case TypeCode.String:
                    _output.Write(p.AsString);
                    return;
                default:
                    _output.Write(Convert.ToString(p.AsObject, _formatProvider));
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
