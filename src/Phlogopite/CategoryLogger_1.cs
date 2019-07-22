using System;
using System.Collections.Generic;
using PropertyCollection = System.ArraySegment<Phlogopite.NamedProperty>;

namespace Phlogopite
{
    public static class CategoryLogger
    {
        public static CategoryLogger<TLogger> Create<TLogger>(TLogger logger, string category)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            return new CategoryLogger<TLogger>(logger, category);
        }

        public static CategoryLogger<TLogger> Create<TLogger>(TLogger logger, Level minimumLevel, string category)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            return new CategoryLogger<TLogger>(logger, minimumLevel, category);
        }
    }

    public readonly struct CategoryLogger<TLogger> : ILogger<NamedProperty, PropertyCollection>,
        IEquatable<CategoryLogger<TLogger>>
        where TLogger : ILogger<NamedProperty, PropertyCollection>
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

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

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public void UncheckedWrite(Level level, string text, PropertyCollection attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            if (_category != null)
            {
                ArraySegmentHelpers.TryAdd(ref attachedProperties,
                    new NamedProperty(KnownProperties.Category, _category));
            }

            _logger.UncheckedWrite(level, text, attachedProperties, userProperties);
        }

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
#pragma warning disable CA1307 // Specify StringComparison
                int hashCode = _category is null ? 0 : _category.GetHashCode();
#pragma warning restore CA1307 // Specify StringComparison
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
