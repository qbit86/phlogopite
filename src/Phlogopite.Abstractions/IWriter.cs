using System;

namespace Phlogopite
{
    public interface IWriter<TProperty>
    {
        bool IsEnabled(Level level);

        void Write(Level level, string text, ReadOnlySpan<TProperty> properties);
    }
}
