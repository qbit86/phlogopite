using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Phlogopite
{
    public sealed class AggregateLogger<TProperty, TProperties> : ILogger<TProperty, TProperties>
    {
        private readonly Func<Exception, bool> _exceptionHandler;
        private readonly IReadOnlyList<ILogger<TProperty, TProperties>> _loggers;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        internal AggregateLogger(IReadOnlyList<ILogger<TProperty, TProperties>> loggers, int maxAttachedPropertyCount,
            Level minimumLevel, Func<Level> minimumLevelProvider, Func<Exception, bool> exceptionHandler)
        {
            Debug.Assert(loggers != null, "loggers != null");
            Debug.Assert(maxAttachedPropertyCount > 0, "maxAttachedPropertyCount > 0");

            _exceptionHandler = exceptionHandler;
            _loggers = loggers;
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
            MaxAttachedPropertyCount = maxAttachedPropertyCount;
        }

        public int MaxAttachedPropertyCount { get; }

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            if (minimumLevel > level)
                return false;

            return _loggers.Count != 0;
        }

        public void UncheckedWrite(Level level, string text, TProperties attachedProperties,
            ReadOnlySpan<TProperty> userProperties)
        {
            List<Exception> exceptions = null;
            int count = _loggers.Count;
            for (int i = 0; i < count; ++i)
            {
                try
                {
                    ILogger<TProperty, TProperties> logger = _loggers[i];
                    if (logger is null || !logger.IsEnabled(level))
                        continue;

                    logger.UncheckedWrite(level, text, attachedProperties, userProperties);
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch (Exception ex)
                {
                    if (exceptions is null)
                        exceptions = new List<Exception>();

                    exceptions.Add(ex);
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }

            if (exceptions is null)
                return;

            var aggregateException = new AggregateException(exceptions);
            if (_exceptionHandler is null)
                throw aggregateException;

            aggregateException.Handle(_exceptionHandler);
        }
    }
}
