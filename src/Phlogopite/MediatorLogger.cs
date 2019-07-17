using System;
using System.Diagnostics;

namespace Phlogopite
{
    public sealed class MediatorLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
    {
        private readonly TimeLogger<AggregateLogger<NamedProperty, ArraySegment<NamedProperty>>> _logger;
        private readonly Level _minimumLevel;
        private readonly Func<Level> _minimumLevelProvider;

        internal MediatorLogger(TimeLogger<AggregateLogger<NamedProperty, ArraySegment<NamedProperty>>> logger,
            Level minimumLevel, Func<Level> minimumLevelProvider)
        {
            Debug.Assert(logger != null, "logger != null");

            _logger = logger;
            _minimumLevel = minimumLevel;
            _minimumLevelProvider = minimumLevelProvider;
        }

        public static MediatorLogger Silent { get; } = new MediatorLoggerBuilder(Level.Silent).Build();

        public int MaxAttachedPropertyCount => _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            Level minimumLevel = _minimumLevelProvider?.Invoke() ?? _minimumLevel;
            if (minimumLevel > level)
                return false;

            return _logger.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, ArraySegment<NamedProperty> attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            _logger.UncheckedWrite(level, text, attachedProperties, userProperties);
        }
    }
}
