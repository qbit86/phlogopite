using System;

namespace Phlogopite
{
    public interface IWriter<TProperty>
    {
        int GetAttachedPropertyCount(Level level);

        bool IsEnabled(Level level);

        void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            Span<TProperty> attachedProperties);
    }
}
