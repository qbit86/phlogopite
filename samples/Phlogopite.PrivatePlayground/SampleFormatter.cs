using System;
using System.Text;
using Phlogopite;
using Range = Phlogopite.Range;

namespace Samples
{
    internal sealed class SampleFormatter : IFormatter<NamedProperty>
    {
        public SampleFormatter(string label)
        {
            Label = label ?? string.Empty;
        }

        private string Label { get; }

        public void Format(Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> attachedProperties,
            StringBuilder output, Span<Range> userRanges, Span<Range> attachedRanges, IFormatProvider formatProvider)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            if (formatProvider is null)
                throw new ArgumentNullException(nameof(formatProvider));

            output.Append(Label);
            output.Append(" ");
            Formatter.Default.Format(level, text, userProperties, attachedProperties,
                output, userRanges, attachedRanges, formatProvider);
            output.Append(" ");
            output.Append(Label);
        }
    }
}
