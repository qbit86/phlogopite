using System;
using System.Text;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public interface IFormatter<TProperty>
    {
        void Format(Level level, string text,
            ReadOnlySpan<TProperty> userProperties, ReadOnlySpan<TProperty> attachedProperties,
            StringBuilder output, Span<Range> userRanges, Span<Range> attachedRanges, IFormatProvider formatProvider);
    }
}
