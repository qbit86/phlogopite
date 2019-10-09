#if PHLOGOPITE_FORMATTING_LOGGER
using System;

namespace Phlogopite
{
    public sealed class FormattedProperties
    {
        public FormattedProperties(IFormatter<NamedProperty> formatter)
        {
            Formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
        }

        /// <summary>
        /// Gets formatter instance used to format this message.
        /// </summary>
        public IFormatter<NamedProperty> Formatter { get; }
    }
}
#endif
