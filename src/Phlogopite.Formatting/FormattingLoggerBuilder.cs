using System;
using System.Collections.Generic;
using System.Threading;

namespace Phlogopite
{
    public sealed class FormattingLoggerBuilder
    {
        private List<ILogger<NamedProperty>> _addedLoggers;
        private IFormatProvider _formatProvider;
        private IFormatter<NamedProperty> _formatter;
        private IEnumerable<ILogger<NamedProperty>> _initialLoggers;

        public FormattingLoggerBuilder(IEnumerable<ILogger<NamedProperty>> loggers = null)
        {
            _initialLoggers = loggers;
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

        public FormattingLogger Build()
        {
            IEnumerable<ILogger<NamedProperty>> initialLoggers = Interlocked.Exchange(ref _initialLoggers, null);
            List<ILogger<NamedProperty>> addedLoggers = Interlocked.Exchange(ref _addedLoggers, null);
            AggregateLogger<NamedProperty> aggregateLogger = CreateAggregateLogger(initialLoggers, addedLoggers);
            return new FormattingLogger(aggregateLogger, Formatter, FormatProvider);
        }

        public FormattingLoggerBuilder AddLogger(ILogger<NamedProperty> logger)
        {
            if (logger is null)
                return this;

            if (_addedLoggers is null)
            {
                _addedLoggers = new List<ILogger<NamedProperty>>(1) { logger };
                return this;
            }

            _addedLoggers.Add(logger);
            return this;
        }

        public FormattingLoggerBuilder AddLoggers(ILogger<NamedProperty> logger0,
            ILogger<NamedProperty> logger1)
        {
            if (logger0 is null)
                return AddLogger(logger1);

            if (logger1 is null)
                return AddLogger(logger0);

            if (_addedLoggers is null)
            {
                _addedLoggers = new List<ILogger<NamedProperty>>(2) { logger0, logger1 };
                return this;
            }

            _addedLoggers.Add(logger0);
            _addedLoggers.Add(logger1);
            return this;
        }

        private AggregateLogger<NamedProperty> CreateAggregateLogger(IEnumerable<ILogger<NamedProperty>> initialLoggers,
            List<ILogger<NamedProperty>> addedLoggers)
        {
            if (addedLoggers is null)
                return AggregateLogger.Create(initialLoggers, ExceptionHandler);

            if (initialLoggers != null)
                addedLoggers.AddRange(initialLoggers);

            return AggregateLogger.Create(addedLoggers, ExceptionHandler);
        }
    }
}
