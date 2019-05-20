using System;
using System.Text;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public interface IFormatter<TProperty>
    {
        void Format(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Range> userSegments,
            Span<Range> writerSegments, Span<Range> mediatorSegments);
    }
}
