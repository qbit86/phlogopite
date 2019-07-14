using System;

namespace Phlogopite
{
    public sealed class TimeLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
    {
        private readonly ILogger<NamedProperty, ArraySegment<NamedProperty>> _logger;

        public TimeLogger(ILogger<NamedProperty, ArraySegment<NamedProperty>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void UncheckedWrite(Level level, string text, ArraySegment<NamedProperty> attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            NamedProperty[] array = attachedProperties.Array;
            int offset = attachedProperties.Offset;
            int oldCount = attachedProperties.Count;

            if (array == null || offset + oldCount >= array.Length)
            {
                _logger.UncheckedWrite(level, text, attachedProperties, userProperties);
                return;
            }

            var newAttachedProperties = new ArraySegment<NamedProperty>(array, offset, oldCount + 1);
            array[offset + oldCount] = new NamedProperty(KnownProperties.Time, DateTime.Now);
            _logger.UncheckedWrite(level, text, newAttachedProperties, userProperties);
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            return _logger.IsEnabled(level);
        }
    }
}
