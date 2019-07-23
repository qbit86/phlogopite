using System;
using PropertyCollection = System.ArraySegment<Phlogopite.NamedProperty>;

namespace Phlogopite
{
    public sealed class SilentLogger : ILogger<NamedProperty, PropertyCollection>
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
