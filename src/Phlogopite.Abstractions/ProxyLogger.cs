using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public readonly struct ProxyLogger<TLogger, TProperty> : ILogger<TProperty>,
        IEquatable<ProxyLogger<TLogger, TProperty>>
        where TLogger : ILogger<TProperty>
    {
        private readonly TLogger _logger;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        public ProxyLogger(TLogger logger, Func<Level> minimumLevelProvider) :
            this(logger, default, minimumLevelProvider) { }

        public ProxyLogger(TLogger logger, Level minimumLevel, Func<Level> minimumLevelProvider = null)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
        }

        public int GetMaxAttachedPropertyCount() => _logger.GetMaxAttachedPropertyCount();

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            if (minimumLevel > level)
                return false;

            return _logger.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            SpanBuilder<TProperty> attachedProperties)
        {
            _logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }

        public bool Equals(ProxyLogger<TLogger, TProperty> other)
        {
            return EqualityComparer<TLogger>.Default.Equals(_logger, other._logger) &&
                _minimumLevel == other._minimumLevel &&
                ReferenceEquals(_minimumLevelProvider, other._minimumLevelProvider);
        }

        public override bool Equals(object obj)
        {
            return obj is ProxyLogger<TLogger, TProperty> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = EqualityComparer<TLogger>.Default.GetHashCode(_logger);
                hashCode = (hashCode * 397) ^ (int)_minimumLevel;
                hashCode = (hashCode * 397) ^ (_minimumLevelProvider?.GetHashCode()).GetValueOrDefault();
                return hashCode;
            }
        }

        public static bool operator ==(ProxyLogger<TLogger, TProperty> left,
            ProxyLogger<TLogger, TProperty> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ProxyLogger<TLogger, TProperty> left,
            ProxyLogger<TLogger, TProperty> right)
        {
            return !left.Equals(right);
        }
    }
}
