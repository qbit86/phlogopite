using System;
using System.Collections.Generic;
using System.Threading;

namespace Phlogopite
{
    public sealed class AggregateLoggerBuilder<TProperty, TProperties>
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        private List<ILogger<TProperty, TProperties>> _loggers;
        private Level? _minimumLevel;

        public Func<Exception, bool> ExceptionHandler { get; set; }

        public Level MinimumLevel
        {
            get => _minimumLevel ?? DefaultMinimumLevel;
            set => _minimumLevel = value;
        }

        public Func<Level> MinimumLevelProvider { get; set; }

        public AggregateLoggerBuilder<TProperty, TProperties> AddLogger(ILogger<TProperty, TProperties> logger)
        {
            if (logger is null)
                return this;

            if (_loggers is null)
            {
                _loggers = new List<ILogger<TProperty, TProperties>>(1) { logger };
                return this;
            }

            _loggers.Add(logger);
            return this;
        }

        public AggregateLoggerBuilder<TProperty, TProperties> AddLoggers(
            ILogger<TProperty, TProperties> logger0, ILogger<TProperty, TProperties> logger1)
        {
            if (logger0 is null)
                return AddLogger(logger1);

            if (logger1 is null)
                return AddLogger(logger0);

            if (_loggers is null)
            {
                _loggers = new List<ILogger<TProperty, TProperties>>(2) { logger0, logger1 };
                return this;
            }

            _loggers.Add(logger0);
            _loggers.Add(logger1);
            return this;
        }

        public AggregateLogger<TProperty, TProperties> Build()
        {
            List<ILogger<TProperty, TProperties>> loggers = Interlocked.Exchange(ref _loggers, null);
            if (loggers is null)
            {
                return new AggregateLogger<TProperty, TProperties>(Array.Empty<ILogger<TProperty, TProperties>>(),
                    0, MinimumLevel, MinimumLevelProvider, ExceptionHandler);
            }

            int maxAttachedPropertyCount = 0;
            foreach (ILogger<TProperty, TProperties> logger in _loggers)
            {
                if (logger.MaxAttachedPropertyCount > maxAttachedPropertyCount)
                    maxAttachedPropertyCount = logger.MaxAttachedPropertyCount;
            }

            return new AggregateLogger<TProperty, TProperties>(Array.Empty<ILogger<TProperty, TProperties>>(),
                maxAttachedPropertyCount, MinimumLevel, MinimumLevelProvider, ExceptionHandler);
        }
    }
}
