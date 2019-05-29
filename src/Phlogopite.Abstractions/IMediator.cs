using System;

namespace Phlogopite
{
    public interface IMediator<TProperty>
    {
        int GetAttachedPropertyCount(Level level);

        bool IsEnabled(Level level);

        void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, Span<TProperty> attachedProperties);
    }
}
