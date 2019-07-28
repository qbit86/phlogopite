using System;

namespace Phlogopite
{
    public interface ILogger<TProperty>
    {
        int MaxAttachedPropertyCount { get; }

        bool IsEnabled(Level level);

        void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            SpanBuilder<TProperty> attachedProperties);
    }
}
