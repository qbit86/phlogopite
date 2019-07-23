using System;
using PropertyCollection = System.ArraySegment<Phlogopite.NamedProperty>;

namespace Phlogopite.Specialized
{
    public readonly struct CategoryLogger : ILogger<NamedProperty, PropertyCollection>,
        IEquatable<CategoryLogger>
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        private readonly string _category;
        private readonly ILogger<NamedProperty, PropertyCollection> _logger;
        private readonly Level _minimumLevel;

        public CategoryLogger(ILogger<NamedProperty, PropertyCollection> logger, string category) :
            this(logger, DefaultMinimumLevel, category) { }

        public CategoryLogger(ILogger<NamedProperty, PropertyCollection> logger, Level minimumLevel,
            string category)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _minimumLevel = minimumLevel;
            _category = category;
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public void UncheckedWrite(Level level, string text, PropertyCollection attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            if (_category != null)
            {
                PropertyCollectionHelpers.TryAdd(ref attachedProperties,
                    new NamedProperty(KnownProperties.Category, _category));
            }

            _logger.UncheckedWrite(level, text, attachedProperties, userProperties);
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level && _logger.IsEnabled(level);
        }

        public bool Equals(CategoryLogger other)
        {
            return string.Equals(_category, other._category, StringComparison.Ordinal) &&
                _logger.Equals(other._logger) && _minimumLevel == other._minimumLevel;
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
                int hashCode = _category is null ? 0 : _category.GetHashCode();
#pragma warning restore CA1307 // Specify StringComparison
                hashCode = (hashCode * 397) ^ _logger.GetHashCode();
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
