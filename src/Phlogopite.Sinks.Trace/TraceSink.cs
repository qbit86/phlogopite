using System;

namespace Phlogopite.Sinks
{
    public sealed class TraceSink : ISink<NamedProperty>, IFormattedSink<NamedProperty>
    {
        public bool IsEnabled(Level level)
        {
            throw new NotImplementedException();
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            throw new NotImplementedException();
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage,
            ReadOnlySpan<Range> userRanges, ReadOnlySpan<Range> writerRanges, ReadOnlySpan<Range> mediatorRanges)
        {
            throw new NotImplementedException();
        }
    }
}
