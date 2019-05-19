using System;

namespace Phlogopite.Sinks
{
    public interface IFormattedSink<TProperty>
    {
        void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties,
            ArraySegment<char> formattedMessage, ReadOnlySpan<Segment> userSegments,
            ReadOnlySpan<Segment> writerSegments, ReadOnlySpan<Segment> mediatorSegments);
    }
}
