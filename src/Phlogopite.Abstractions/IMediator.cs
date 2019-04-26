using System;

namespace Phlogopite
{
    public interface IMediator<TProperty>
    {
        bool IsEnabled(Level level);

        void Write(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties);
    }
}
