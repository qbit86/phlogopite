using System;
using System.Diagnostics;

namespace Phlogopite
{
    public abstract class AggregateLoggerBase : ILoggerBase
    {
        protected readonly Func<Exception, bool> _exceptionHandler;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        internal AggregateLoggerBase(int maxAttachedPropertyCount,
            Level minimumLevel, Func<Level> minimumLevelProvider, Func<Exception, bool> exceptionHandler)
        {
            Debug.Assert(maxAttachedPropertyCount > 0, "maxAttachedPropertyCount > 0");

            _exceptionHandler = exceptionHandler;
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
            MaxAttachedPropertyCount = maxAttachedPropertyCount;
        }

        public int MaxAttachedPropertyCount { get; }

        public virtual bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            return minimumLevel <= level;
        }
    }
}
