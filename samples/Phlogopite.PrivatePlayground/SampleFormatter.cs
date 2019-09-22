using System;
using System.Text;
using Phlogopite;

namespace Samples
{
    internal sealed class SampleFormatter : IFormatter<NamedProperty>
    {
        public SampleFormatter(string label)
        {
            Label = label ?? string.Empty;
        }

        private string Label { get; }

        public void Format(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> attachedProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Range> userRanges, Span<Range> attachedRanges)
        {
            if (formatProvider is null)
                throw new ArgumentNullException(nameof(formatProvider));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            output.Append(Label);
            output.Append(" ");
            Formatter.Default.Format(level, text, userProperties, attachedProperties, formatProvider, output,
                userRanges, attachedRanges);
            output.Append(" ");
            output.Append(Label);
        }
    }
}
