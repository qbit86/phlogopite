using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public sealed class FormattingLoggerBuilder
    {
        private IFormatProvider _formatProvider;
        private IFormatter<NamedProperty> _formatter;
        private ICollection<ILogger<NamedProperty>> _loggers;

        public FormattingLoggerBuilder(ICollection<ILogger<NamedProperty>> loggers = null)
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

        public FormattingLoggerBuilder AddLogger(ILogger<NamedProperty> logger)
        {
            if (logger is null)
                return this;

            if (_loggers is null)
            {
                _loggers = new List<ILogger<NamedProperty>>(1) { logger };
                return this;
            }

            if (_loggers.IsReadOnly || _loggers is ILogger<NamedProperty>[])
            {
                _loggers = new List<ILogger<NamedProperty>>(_loggers) { logger };
                return this;
            }

            _loggers.Add(logger);
            return this;
        }

        public FormattingLoggerBuilder AddLoggers(ILogger<NamedProperty> logger0,
            ILogger<NamedProperty> logger1)
        {
            if (logger0 is null)
                return AddLogger(logger1);

            if (logger1 is null)
                return AddLogger(logger0);

            if (_loggers is null)
            {
                _loggers = new List<ILogger<NamedProperty>>(2) { logger0, logger1 };
                return this;
            }

            if (_loggers.IsReadOnly || _loggers is ILogger<NamedProperty>[])
            {
                _loggers = new List<ILogger<NamedProperty>>(_loggers) { logger0, logger1 };
                return this;
            }

            _loggers.Add(logger0);
            _loggers.Add(logger1);
            return this;
        }
    }
}
