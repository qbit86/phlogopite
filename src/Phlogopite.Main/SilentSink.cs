using System;

namespace Phlogopite
{
    public sealed class SilentSink : ISink<NamedProperty>
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
    }
}
