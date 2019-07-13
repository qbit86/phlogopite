using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Phlogopite
{
    public sealed class AggregateLogger<TProperty, TProperties> : AggregateLoggerBase
    {
        private readonly IReadOnlyList<ILogger<TProperty, TProperties>> _loggers;

        internal AggregateLogger(IReadOnlyList<ILogger<TProperty, TProperties>> loggers, int maxAttachedPropertyCount,
            Level minimumLevel, Func<Level> minimumLevelProvider, Func<Exception, bool> exceptionHandler) :
            base(maxAttachedPropertyCount, minimumLevel, minimumLevelProvider, exceptionHandler)
        {
            Debug.Assert(loggers != null, "loggers != null");

            _loggers = loggers;
        }

        public override bool IsEnabled(Level level)
        {
            return base.IsEnabled(level) && _loggers.Count != 0;
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
