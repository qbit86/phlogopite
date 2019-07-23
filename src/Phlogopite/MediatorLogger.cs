using System;
using System.Diagnostics;
using PropertyCollection = System.ArraySegment<Phlogopite.NamedProperty>;

namespace Phlogopite
{
    public sealed class MediatorLogger : ILogger<NamedProperty, PropertyCollection>
    {
        private readonly AggregateLogger<NamedProperty, PropertyCollection> _logger;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        internal MediatorLogger(AggregateLogger<NamedProperty, PropertyCollection> logger,
            Level minimumLevel, Func<Level> minimumLevelProvider)
        {
            Debug.Assert(logger != null, "logger != null");

            _logger = logger;
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
        }

        public static MediatorLogger Silent { get; } = new MediatorLoggerBuilder(Level.Silent).Build();

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            if (minimumLevel > level)
                return false;

            return _logger.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, PropertyCollection attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            CollectionHelpers.TryAppend(ref attachedProperties, new NamedProperty(KnownProperties.Time, DateTime.Now));
            _logger.UncheckedWrite(level, text, attachedProperties, userProperties);
        }
    }
}
