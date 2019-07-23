using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Phlogopite
{
    public static class AggregateLogger
    {
        public static AggregateLogger<TProperty, TProperties> Create<TProperty, TProperties>(
            IEnumerable<ILogger<TProperty, TProperties>> loggers = null, Func<Exception, bool> exceptionHandler = null)
        {
            ILogger<TProperty, TProperties>[] array =
                loggers?.ToArray() ?? Array.Empty<ILogger<TProperty, TProperties>>();
            int maxAttachedPropertyCount = 0;
            for (int i = 0; i != array.Length; ++i)
            {
                ILogger<TProperty, TProperties> logger = array[i];
                if (logger is null)
                    continue;

                if (logger.MaxAttachedPropertyCount > maxAttachedPropertyCount)
                    maxAttachedPropertyCount = logger.MaxAttachedPropertyCount;
            }

            return new AggregateLogger<TProperty, TProperties>(array, maxAttachedPropertyCount, exceptionHandler);
        }
    }

    public readonly struct AggregateLogger<TProperty, TProperties> : ILogger<TProperty, TProperties>,
        IEquatable<AggregateLogger<TProperty, TProperties>>
    {
        private readonly ILogger<TProperty, TProperties>[] _loggers;
        private readonly Func<Exception, bool> _exceptionHandler;

        internal AggregateLogger(ILogger<TProperty, TProperties>[] loggers, int maxAttachedPropertyCount,
            Func<Exception, bool> exceptionHandler)
        {
            Debug.Assert(loggers != null, "loggers != null");
            Debug.Assert(maxAttachedPropertyCount >= 0, "maxAttachedPropertyCount >= 0");

            _loggers = loggers;
            _exceptionHandler = exceptionHandler;
            MaxAttachedPropertyCount = maxAttachedPropertyCount;
        }

        public int MaxAttachedPropertyCount { get; }

        public bool IsEnabled(Level level)
        {
            return _loggers.Length != 0;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            TProperties attachedProperties)
        {
            List<Exception> exceptions = null;
            for (int i = 0; i != _loggers.Length; ++i)
            {
                try
                {
                    ILogger<TProperty, TProperties> logger = _loggers[i];
                    if (logger is null || !logger.IsEnabled(level))
                        continue;

                    logger.UncheckedWrite(level, text, userProperties, attachedProperties);
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

        public bool Equals(AggregateLogger<TProperty, TProperties> other)
        {
            return Equals(_loggers, other._loggers) && Equals(_exceptionHandler, other._exceptionHandler) &&
                MaxAttachedPropertyCount == other.MaxAttachedPropertyCount;
        }

        public override bool Equals(object obj)
        {
            return obj is AggregateLogger<TProperty, TProperties> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _exceptionHandler is null ? 0 : _exceptionHandler.GetHashCode();
                hashCode = (hashCode * 397) ^ _loggers.GetHashCode();
                hashCode = (hashCode * 397) ^ MaxAttachedPropertyCount;
                return hashCode;
            }
        }

        public static bool operator ==(AggregateLogger<TProperty, TProperties> left,
            AggregateLogger<TProperty, TProperties> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AggregateLogger<TProperty, TProperties> left,
            AggregateLogger<TProperty, TProperties> right)
        {
            return !left.Equals(right);
        }
    }
}
