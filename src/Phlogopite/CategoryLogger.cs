using System;
using System.Collections.Generic;
using Phlogopite.Internal;

namespace Phlogopite
{
    using PropertyCollection = SpanBuilder<NamedProperty>;
    using TLogger = ILogger<NamedProperty>;

    public readonly struct CategoryLogger : ILogger<NamedProperty>,
        IEquatable<CategoryLogger>
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        private readonly string _category;
        private readonly TLogger _logger;
        private readonly Level _minimumLevel;

        public CategoryLogger(TLogger logger, string category) :
            this(logger, DefaultMinimumLevel, category) { }

        public CategoryLogger(TLogger logger, Level minimumLevel, string category)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _minimumLevel = minimumLevel;
            _category = category ?? throw new ArgumentNullException(nameof(category));
        }

        public bool IsDefault => _category is null;

        public int GetMaxAttachedPropertyCount() => 1 + _logger.GetMaxAttachedPropertyCount();

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            CollectionHelpers.TryAppend(ref attachedProperties,
                new NamedProperty(KnownProperties.Category, _category));

            _logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level && _logger.IsEnabled(level);
        }

        public bool Equals(CategoryLogger other)
        {
            return string.Equals(_category, other._category, StringComparison.Ordinal) &&
                EqualityComparer<TLogger>.Default.Equals(_logger, other._logger) &&
                _minimumLevel == other._minimumLevel;
        }

        public override bool Equals(object obj)
        {
            return obj is CategoryLogger other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
#pragma warning disable CA1307 // Specify StringComparison
                int hashCode = _category.GetHashCode();
#pragma warning restore CA1307 // Specify StringComparison
                hashCode = (hashCode * 397) ^ EqualityComparer<TLogger>.Default.GetHashCode(_logger);
                hashCode = (hashCode * 397) ^ (int)_minimumLevel;
                return hashCode;
            }
        }

        public static bool operator ==(CategoryLogger left, CategoryLogger right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CategoryLogger left, CategoryLogger right)
        {
            return !left.Equals(right);
        }
    }
}
