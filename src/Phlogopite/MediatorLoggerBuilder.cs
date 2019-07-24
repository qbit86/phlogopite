using System;
using System.Collections.Generic;
using PropertyCollection = Phlogopite.SpanBuilder<Phlogopite.NamedProperty>;

namespace Phlogopite
{
    public sealed class MediatorLoggerBuilder
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        private ICollection<ILogger<NamedProperty, PropertyCollection>> _loggers;
        private Level? _minimumLevel;

        public MediatorLoggerBuilder(ICollection<ILogger<NamedProperty, PropertyCollection>> loggers)
        {
            _loggers = loggers;
        }

        public MediatorLoggerBuilder(Level minimumLevel)
        {
            _minimumLevel = minimumLevel;
        }

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public Level MinimumLevel
        {
            get => _minimumLevel ?? DefaultMinimumLevel;
            set => _minimumLevel = value;
        }

        public Func<Level> MinimumLevelProvider { get; set; }

        public ICollection<ILogger<NamedProperty, PropertyCollection>> Loggers =>
            _loggers ?? Array.Empty<ILogger<NamedProperty, PropertyCollection>>();

        public MediatorLogger Build()
        {
            AggregateLogger<NamedProperty, PropertyCollection> aggregateLogger =
                AggregateLogger.Create(_loggers, ExceptionHandler);

            return new MediatorLogger(aggregateLogger, MinimumLevel, MinimumLevelProvider);
        }

        public MediatorLoggerBuilder AddLogger(ILogger<NamedProperty, PropertyCollection> logger)
        {
            if (logger is null)
                return this;

            if (_loggers is null)
            {
                _loggers = new List<ILogger<NamedProperty, PropertyCollection>>(1) { logger };
                return this;
            }

            if (_loggers.IsReadOnly || _loggers is ILogger<NamedProperty, PropertyCollection>[])
            {
                _loggers = new List<ILogger<NamedProperty, PropertyCollection>>(_loggers) { logger };
                return this;
            }

            _loggers.Add(logger);
            return this;
        }

        public MediatorLoggerBuilder AddLoggers(ILogger<NamedProperty, PropertyCollection> logger0,
            ILogger<NamedProperty, PropertyCollection> logger1)
        {
            if (logger0 is null)
                return AddLogger(logger1);

            if (logger1 is null)
                return AddLogger(logger0);

            if (_loggers is null)
            {
                _loggers = new List<ILogger<NamedProperty, PropertyCollection>>(2) { logger0, logger1 };
                return this;
            }

            if (_loggers.IsReadOnly || _loggers is ILogger<NamedProperty, PropertyCollection>[])
            {
                _loggers = new List<ILogger<NamedProperty, PropertyCollection>>(_loggers) { logger0, logger1 };
                return this;
            }

            _loggers.Add(logger0);
            _loggers.Add(logger1);
            return this;
        }
    }
}
