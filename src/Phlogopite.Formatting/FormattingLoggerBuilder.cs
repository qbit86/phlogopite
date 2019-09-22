using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class FormattingLoggerBuilder
    {
        private IFormatProvider _formatProvider;
        private IFormatter<NamedProperty> _formatter;
        private ICollection<ILogger<NamedProperty>> _loggers;

        public FormattingLoggerBuilder(ICollection<ILogger<NamedProperty>> loggers)
        {
            _loggers = loggers;
        }

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public IFormatProvider FormatProvider
        {
            get => _formatProvider ?? CultureConstants.FixedCulture;
            set => _formatProvider = value;
        }

        public IFormatter<NamedProperty> Formatter
        {
            get => _formatter ?? Phlogopite.Formatter.Default;
            set => _formatter = value;
        }

        public ICollection<ILogger<NamedProperty>> Loggers =>
            _loggers ?? Array.Empty<ILogger<NamedProperty>>();

        public FormattingLogger Build()
        {
            AggregateLogger<NamedProperty> aggregateLogger =
                AggregateLogger.Create(_loggers, ExceptionHandler);

            return new FormattingLogger(aggregateLogger, Formatter, FormatProvider);
        }
    }
}
