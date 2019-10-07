using System;
using System.Text;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public interface IPropertyFormatter<TProperty>
    {
        void Format(ReadOnlySpan<TProperty> userProperties, ReadOnlySpan<TProperty> attachedProperties,
            StringBuilder output, Span<Range> userRanges, Span<Range> attachedRanges, IFormatProvider formatProvider);
    }
}
