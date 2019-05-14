using System;
using System.Text;

namespace Phlogopite
{
    public interface IFormatter<TProperty>
    {
        void Format(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Segment> userSegments,
            Span<Segment> writerSegments, Span<Segment> mediatorSegments);
    }
}
