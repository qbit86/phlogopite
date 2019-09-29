using System;
using System.Text;

namespace Phlogopite
{
    public class PropertiesFormatter : IPropertiesFormatter<NamedProperty>
    {
        private PropertiesFormatter() { }

        public static PropertiesFormatter Default { get; } = new PropertiesFormatter();

        public void Format(ReadOnlySpan<NamedProperty> userProperties, ReadOnlySpan<NamedProperty> attachedProperties,
            StringBuilder output, Span<Range> userRanges, Span<Range> attachedRanges, IFormatProvider formatProvider)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            if (formatProvider is null)
                throw new ArgumentNullException(nameof(formatProvider));

            FormatUserProperties(userProperties, output, userRanges, formatProvider);
            FormatAttachedProperties(attachedProperties, output, attachedRanges, formatProvider);
        }

        private void FormatUserProperties(ReadOnlySpan<NamedProperty> userProperties,
            StringBuilder output, Span<Range> userRanges, IFormatProvider formatProvider)
        {
            var sbf = new StringBuilderFacade(output, formatProvider);
            for (int i = 0; i != userProperties.Length; ++i)
            {
                if (i != 0)
                    output.Append(", ");

                if (!string.IsNullOrEmpty(userProperties[i].Name))
                {
                    output.Append(userProperties[i].Name);
                    output.Append(": ");
                }

                int propertyOffset = output.Length;
                RenderingHelpers.RenderValue(userProperties[i], sbf);
                SetRange(i, propertyOffset, output, userRanges);
            }
        }

        private void FormatAttachedProperties(ReadOnlySpan<NamedProperty> attachedProperties,
            StringBuilder output, Span<Range> attachedRanges, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        private static void SetRange(int rangeIndex, int propertyOffset, StringBuilder sb, Span<Range> ranges)
        {
            if ((uint)rangeIndex >= (uint)ranges.Length)
                return;

            ranges[rangeIndex] = new Range(propertyOffset, sb.Length);
        }
    }
}
