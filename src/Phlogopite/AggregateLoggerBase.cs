using System;
using System.Diagnostics;

namespace Phlogopite
{
    public abstract class AggregateLoggerBase : ILoggerBase
    {
        internal AggregateLoggerBase(int maxAttachedPropertyCount,
            Level minimumLevel, Func<Level> minimumLevelProvider, Func<Exception, bool> exceptionHandler)
        {
            Debug.Assert(maxAttachedPropertyCount > 0, "maxAttachedPropertyCount > 0");

            ExceptionHandler = exceptionHandler;
            MinimumLevel = minimumLevel;
            MinimumLevelProvider = minimumLevelProvider;
            MaxAttachedPropertyCount = maxAttachedPropertyCount;
        }

        protected Func<Exception, bool> ExceptionHandler { get; }

        protected Level MinimumLevel { get; }

        protected Func<Level> MinimumLevelProvider { get; }

        public int MaxAttachedPropertyCount { get; }

        public abstract bool IsEnabled(Level level);
    }
}
