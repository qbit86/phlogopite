using System;
using System.Collections.Generic;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Phlogopite
{
    public sealed class MediatorLoggerBuilder
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        private ICollection<ILogger<NamedProperty, ArraySegment<NamedProperty>>> _loggers;
        private Level? _minimumLevel;

        public MediatorLoggerBuilder(ICollection<ILogger<NamedProperty, ArraySegment<NamedProperty>>> loggers)
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

        public ICollection<ILogger<NamedProperty, ArraySegment<NamedProperty>>> Loggers =>
            _loggers ?? Array.Empty<ILogger<NamedProperty, ArraySegment<NamedProperty>>>();

        public MediatorLogger Build()
        {
            AggregateLogger<NamedProperty, ArraySegment<NamedProperty>> aggregateLogger =
                AggregateLogger.Create(_loggers, ExceptionHandler);

            var timeLogger =
                new TimeLogger<AggregateLogger<NamedProperty, ArraySegment<NamedProperty>>>(aggregateLogger);

            return new MediatorLogger(timeLogger, MinimumLevel, MinimumLevelProvider);
        }

        public MediatorLoggerBuilder AddLogger(ILogger<NamedProperty, ArraySegment<NamedProperty>> logger)
        {
            if (logger is null)
                return this;

            if (_loggers is null)
            {
                _loggers = new List<ILogger<NamedProperty, ArraySegment<NamedProperty>>>(1) { logger };
                return this;
            }

            if (_loggers.IsReadOnly || _loggers is ILogger<NamedProperty, ArraySegment<NamedProperty>>[])
            {
                _loggers = new List<ILogger<NamedProperty, ArraySegment<NamedProperty>>>(_loggers) { logger };
                return this;
            }

            _loggers.Add(logger);
            return this;
        }

        public MediatorLoggerBuilder AddLoggers(ILogger<NamedProperty, ArraySegment<NamedProperty>> logger0,
            ILogger<NamedProperty, ArraySegment<NamedProperty>> logger1)
        {
            if (logger0 is null)
                return AddLogger(logger1);

            if (logger1 is null)
                return AddLogger(logger0);

            if (_loggers is null)
            {
                _loggers = new List<ILogger<NamedProperty, ArraySegment<NamedProperty>>>(2) { logger0, logger1 };
                return this;
            }

            if (_loggers.IsReadOnly || _loggers is ILogger<NamedProperty, ArraySegment<NamedProperty>>[])
            {
                _loggers = new List<ILogger<NamedProperty, ArraySegment<NamedProperty>>>(_loggers) { logger0, logger1 };
                return this;
            }

            _loggers.Add(logger0);
            _loggers.Add(logger1);
            return this;
        }
    }
}
