using System;

namespace Phlogopite
{
    public interface IFormattedSink<TProperty>
    {
        void Write(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties,
            ArraySegment<char> formattedMessage, ReadOnlySpan<Segment> userSegments,
            ReadOnlySpan<Segment> writerSegments, ReadOnlySpan<Segment> mediatorSegments);
    }
}
