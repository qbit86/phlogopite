using System;
using System.Diagnostics;
using Phlogopite.Internal;

namespace Phlogopite
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public sealed class FormattingLogger : ILogger<NamedProperty>
    {
        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly AggregateLogger<NamedProperty> _logger;

        internal FormattingLogger(AggregateLogger<NamedProperty> logger, IFormatter<NamedProperty> formatter,
            IFormatProvider formatProvider)
        {
            Debug.Assert(logger != null, "logger != null");

            _logger = logger;
            _formatter = formatter ?? Formatter.Default;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            return _logger.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            var item = new NamedProperty(KnownProperties.FormattedMessage,
                FormatMessage(level, text, userProperties, attachedProperties));
            attachedProperties.TryAppend(item, out attachedProperties);
            _logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }

        private FormattedMessage FormatMessage(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            // TODO: To be implemented.
            return new FormattedMessage(_formatter);
        }
    }
}
