using System;

namespace Phlogopite.Sinks
{
    public interface IFormattedSink<TProperty>
    {
        void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties,
            ArraySegment<char> formattedMessage, ReadOnlySpan<Range> userSegments,
            ReadOnlySpan<Range> writerSegments, ReadOnlySpan<Range> mediatorSegments);
    }
}
