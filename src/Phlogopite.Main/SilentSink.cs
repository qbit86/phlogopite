using System;

namespace Phlogopite
{
    public sealed class SilentSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>
    {
        public static SilentSink Default { get; } = new SilentSink();

        public bool IsEnabled(Level level)
        {
            return false;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
        }
    }
}
