using System;
using System.Text;

namespace Phlogopite
{
    public sealed class Formatter
    {
        public static Formatter Default { get; } = new Formatter();

        private Formatter() { }

        public void Format(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Segment> userSegments,
            Span<Segment> writerSegments, Span<Segment> mediatorSegments)
        {
            if (formatProvider == null)
                throw new ArgumentNullException(nameof(formatProvider));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            RenderLevel(level, output);
            output.Append(" ");
        }

        private static void RenderLevel(Level level, StringBuilder output)
        {
            switch (level)
            {
                case Level.Verbose:
                    output.Append("V");
                    break;
                case Level.Debug:
                    output.Append("D");
                    break;
                case Level.Info:
                    output.Append("I");
                    break;
                case Level.Warning:
                    output.Append("W");
                    break;
                case Level.Error:
                    output.Append("E");
                    break;
                case Level.Assert:
                    output.Append("A");
                    break;
                default:
                    output.Append("-");
                    break;
            }
        }
    }
}
