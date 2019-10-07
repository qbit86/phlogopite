using System;
using System.Text;
using Phlogopite.Internal;

namespace Phlogopite
{
    public class PropertyFormatter : IPropertyFormatter<NamedProperty>
    {
        private PropertyFormatter() { }

        public static PropertyFormatter Default { get; } = new PropertyFormatter();

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

                NamedProperty p = userProperties[i];
                if (!string.IsNullOrEmpty(p.Name))
                    output.Append(p.Name).Append(": ");

                int propertyOffset = output.Length;
                RenderingHelpers.RenderValue(p, sbf);
                SetRange(i, propertyOffset, output, userRanges);
            }
        }

        private void FormatAttachedProperties(ReadOnlySpan<NamedProperty> attachedProperties,
            StringBuilder output, Span<Range> attachedRanges, IFormatProvider formatProvider)
        {
            // Searching for time only.
            for (int i = 0; i != attachedProperties.Length; ++i)
            {
                NamedProperty p = attachedProperties[i];

                if (!ReferenceEquals(p.Name, KnownProperties.Time))
                    continue;

                if (!p.TryGetDateTime(out DateTime value))
                    continue;

                var sbf = new StringBuilderFacade(output, formatProvider);
                int propertyOffset = output.Length;
                sbf.Append(value, "HH:mm:ss.fff");
                SetRange(i, propertyOffset, output, attachedRanges);
                return;
            }
        }

        private static void SetRange(int rangeIndex, int propertyOffset, StringBuilder sb, Span<Range> ranges)
        {
            if ((uint)rangeIndex >= (uint)ranges.Length)
                return;

            ranges[rangeIndex] = new Range(propertyOffset, sb.Length);
        }
    }
}
