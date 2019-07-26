using System;

namespace Phlogopite
{
    public interface ILogger<TProperty, in TProperties>
    {
        int MaxAttachedPropertyCount { get; }

        bool IsEnabled(Level level);

        void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            TProperties attachedProperties);
    }
}
