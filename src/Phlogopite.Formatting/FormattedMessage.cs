using System;

namespace Phlogopite
{
    public sealed class FormattedMessage
    {
        public FormattedMessage(IFormatter<NamedProperty> formatter)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        /// <summary>
        /// Gets formatter instance used to format this message.
        /// </summary>
        public IFormatter<NamedProperty> Formatter { get; }
    }
}
