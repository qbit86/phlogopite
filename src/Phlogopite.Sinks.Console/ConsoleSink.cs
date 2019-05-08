using System;
using System.IO;

namespace Phlogopite
{
    public sealed class ConsoleSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>
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
                    && string.Equals(mediatorProperties[0].Name, "time", StringComparison.Ordinal)
                    && mediatorProperties[0].TryGetDateTime(out DateTime time))
                {
                    RenderTime(time);
                }
                else
                {
                    _output.Write("            ");
                }

                _output.Write(" ");
                TryGetString(writerProperties, "tag", out string tag);
                TryGetString(writerProperties, "source", out string source);
                if (tag != null || source != null)
                {
                    _output.Write("[");
                    if (!string.IsNullOrEmpty(tag))
                        _output.Write(tag);

                    if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(source))
                        _output.Write(".");

                    if (!string.IsNullOrEmpty(source))
                        _output.Write(source);

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

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            Write(level, text, userProperties, writerProperties, default);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            Write(level, text, properties, default, default);
        }

        private bool TryGetString(ReadOnlySpan<NamedProperty> properties, string name, out string value)
        {
            foreach (NamedProperty p in properties)
            {
                if (!string.Equals(p.Name, name, StringComparison.Ordinal))
                    continue;

                if (p.TryGetString(out value))
                    return true;
            }

            value = default;
            return false;
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

        private void RenderTime(DateTime time)
        {
            const string format = "HH:mm:ss.fff";
            _renderer.Render(time, format);
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
                    _renderer.Render(p.AsSByte, "x2");
                    return;
                case TypeCode.Byte:
                    _renderer.Render(p.AsByte, "x2");
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
