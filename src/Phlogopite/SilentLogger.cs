using System;

namespace Phlogopite
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public sealed class SilentLogger : ILogger<NamedProperty>
    {
        private SilentLogger() { }

        public static SilentLogger Default { get; } = new SilentLogger();

        int ILogger<NamedProperty, PropertyCollection>.MaxAttachedPropertyCount => 0;

        bool ILogger<NamedProperty, PropertyCollection>.IsEnabled(Level level)
        {
            return false;
        }

        void ILogger<NamedProperty, PropertyCollection>.UncheckedWrite(Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, PropertyCollection attachedProperties) { }
    }
}
