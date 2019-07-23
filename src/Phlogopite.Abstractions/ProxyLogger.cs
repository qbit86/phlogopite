using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public readonly struct ProxyLogger<TLogger, TProperty, TProperties> : ILogger<TProperty, TProperties>,
        IEquatable<ProxyLogger<TLogger, TProperty, TProperties>>
        where TLogger : ILogger<TProperty, TProperties>
    {
        private readonly TLogger _logger;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        public ProxyLogger(TLogger logger, Level minimumLevel) :
            this(logger, minimumLevel, null) { }

        public ProxyLogger(TLogger logger, Func<Level> minimumLevelProvider) :
            this(logger, default, minimumLevelProvider) { }

        public ProxyLogger(TLogger logger, Level minimumLevel, Func<Level> minimumLevelProvider)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
        }

        public int MaxAttachedPropertyCount => _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            if (minimumLevel > level)
                return false;

            return _logger.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            TProperties attachedProperties)
        {
            _logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }

        public bool Equals(ProxyLogger<TLogger, TProperty, TProperties> other)
        {
            return EqualityComparer<TLogger>.Default.Equals(_logger, other._logger) &&
                _minimumLevel == other._minimumLevel &&
                ReferenceEquals(_minimumLevelProvider, other._minimumLevelProvider);
        }

        public override bool Equals(object obj)
        {
            return obj is ProxyLogger<TLogger, TProperty, TProperties> other && Equals(other);
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

        public static bool operator ==(ProxyLogger<TLogger, TProperty, TProperties> left,
            ProxyLogger<TLogger, TProperty, TProperties> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ProxyLogger<TLogger, TProperty, TProperties> left,
            ProxyLogger<TLogger, TProperty, TProperties> right)
        {
            return !left.Equals(right);
        }
    }
}
