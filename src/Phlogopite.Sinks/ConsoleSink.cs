using System;

namespace Phlogopite
{
    public sealed class ConsoleSink : ISink<Property>
    {
        private readonly Level _level;

        public ConsoleSink(Level level)
        {
            _level = level;
        }

        public bool IsEnabled(Level level)
        {
            return _level <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<Property> userProperties,
            ReadOnlySpan<Property> writerProperties, ReadOnlySpan<Property> mediatorProperties)
        {
            throw new NotImplementedException();
        }
    }
}
