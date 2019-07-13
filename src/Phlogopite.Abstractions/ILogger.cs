using System;

namespace Phlogopite
{
    public interface ILoggerBase
    {
        int MaxAttachedPropertyCount { get; }

        bool IsEnabled(Level level);
    }

    public interface ILogger<TProperty, in TProperties> : ILoggerBase
    {
        void UncheckedWrite(Level level, string text, TProperties attachedProperties,
            ReadOnlySpan<TProperty> userProperties);
    }
}
