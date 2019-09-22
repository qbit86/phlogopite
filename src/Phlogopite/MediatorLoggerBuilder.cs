using System;
using System.Collections.Generic;
using System.Threading;

namespace Phlogopite
{
    public sealed class MediatorLoggerBuilder
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        private List<ILogger<NamedProperty>> _addedLoggers;
        private IEnumerable<ILogger<NamedProperty>> _initialLoggers;
        private Level? _minimumLevel;

        public MediatorLoggerBuilder(IEnumerable<ILogger<NamedProperty>> loggers = null, Level minimumLevel = default)
        {
            _initialLoggers = loggers;
            _minimumLevel = minimumLevel;
        }

        public MediatorLoggerBuilder(Level minimumLevel) : this(null, minimumLevel) { }

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public Level MinimumLevel
        {
            get => _minimumLevel ?? DefaultMinimumLevel;
            set => _minimumLevel = value;
        }

        public Func<Level> MinimumLevelProvider { get; set; }

        public MediatorLogger Build()
        {
            IEnumerable<ILogger<NamedProperty>> initialLoggers = Interlocked.Exchange(ref _initialLoggers, null);
            List<ILogger<NamedProperty>> addedLoggers = Interlocked.Exchange(ref _addedLoggers, null);
            AggregateLogger<NamedProperty> aggregateLogger = CreateAggregateLogger(initialLoggers, addedLoggers);
            return new MediatorLogger(aggregateLogger, MinimumLevel, MinimumLevelProvider);
        }

        public MediatorLoggerBuilder AddLogger(ILogger<NamedProperty> logger)
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

        public MediatorLoggerBuilder AddLoggers(ILogger<NamedProperty> logger0,
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
