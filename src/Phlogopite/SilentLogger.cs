using System;

namespace Phlogopite
{
    public sealed class SilentLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
    {
        private SilentLogger() { }

        public static SilentLogger Default { get; } = new SilentLogger();

        int ILogger<NamedProperty, ArraySegment<NamedProperty>>.MaxAttachedPropertyCount => 0;

        bool ILogger<NamedProperty, ArraySegment<NamedProperty>>.IsEnabled(Level level)
        {
            return false;
        }

        void ILogger<NamedProperty, ArraySegment<NamedProperty>>.UncheckedWrite(Level level, string text,
            ArraySegment<NamedProperty> attachedProperties, ReadOnlySpan<NamedProperty> userProperties) { }
    }
}
