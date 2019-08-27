using System;
using System.Diagnostics;
using Phlogopite.Internal;

namespace Phlogopite
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public sealed class FormattingLogger : ILogger<NamedProperty>
    {
        private readonly AggregateLogger<NamedProperty> _logger;

        internal FormattingLogger(AggregateLogger<NamedProperty> logger)
        {
            Debug.Assert(logger != null, "logger != null");

            _logger = logger;
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            return _logger.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            // TODO: To be implemented.
            var item = new NamedProperty(KnownProperties.FormattedMessage, new object());
            attachedProperties.TryAppend(item, out attachedProperties);
            _logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }
    }
}
