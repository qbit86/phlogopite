using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public readonly struct CategoryLogger<TLogger> : ILogger<NamedProperty, ArraySegment<NamedProperty>>,
        IEquatable<CategoryLogger<TLogger>>
        where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
    {
        internal const Level DefaultMinimumLevel = Level.Verbose;

        private readonly string _category;
        private readonly TLogger _logger;
        private readonly Level _minimumLevel;

        public CategoryLogger(TLogger logger, string category) :
            this(logger, DefaultMinimumLevel, category) { }

        public CategoryLogger(TLogger logger, Level minimumLevel, string category)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _minimumLevel = minimumLevel;
            _category = category;
        }

        public void UncheckedWrite(Level level, string text, ArraySegment<NamedProperty> attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            throw new NotImplementedException();
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level && _logger.IsEnabled(level);
        }

        public bool Equals(CategoryLogger<TLogger> other)
        {
            return string.Equals(_category, other._category, StringComparison.Ordinal) &&
                EqualityComparer<TLogger>.Default.Equals(_logger, other._logger) &&
                _minimumLevel == other._minimumLevel;
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryLogger<TLogger> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _category != null ? _category.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ EqualityComparer<TLogger>.Default.GetHashCode(_logger);
                hashCode = (hashCode * 397) ^ (int)_minimumLevel;
                return hashCode;
            }
        }

        public static bool operator ==(CategoryLogger<TLogger> left, CategoryLogger<TLogger> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CategoryLogger<TLogger> left, CategoryLogger<TLogger> right)
        {
            return !left.Equals(right);
        }
    }
}
