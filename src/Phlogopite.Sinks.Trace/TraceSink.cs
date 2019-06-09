using System;

namespace Phlogopite.Sinks
{
    public sealed class TraceSink : ISink<NamedProperty>, IFormattedSink<NamedProperty>
    {
        internal const Level DefaultMinimumLevel = Level.Verbose;

        private readonly Level _minimumLevel;

        public TraceSink() : this(DefaultMinimumLevel) { }

        public TraceSink(Level minimumLevel)
        {
            _minimumLevel = minimumLevel;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage,
            ReadOnlySpan<Range> userRanges, ReadOnlySpan<Range> writerRanges, ReadOnlySpan<Range> mediatorRanges)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            throw new NotImplementedException();
        }
    }
}
