using System;
using System.Collections.Generic;

namespace Phlogopite
{
    public readonly struct TimeLogger<TLogger> : ILogger<NamedProperty, ArraySegment<NamedProperty>>,
        IEquatable<TimeLogger<TLogger>>
        where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
    {
        private readonly TLogger _logger;

        public TimeLogger(TLogger logger)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
        }

        public void UncheckedWrite(Level level, string text, ArraySegment<NamedProperty> attachedProperties,
            ReadOnlySpan<NamedProperty> userProperties)
        {
            NamedProperty[] array = attachedProperties.Array;
            int offset = attachedProperties.Offset;
            int oldCount = attachedProperties.Count;

            if (array == null || offset + oldCount >= array.Length)
            {
                _logger.UncheckedWrite(level, text, attachedProperties, userProperties);
                return;
            }

            var newAttachedProperties = new ArraySegment<NamedProperty>(array, offset, oldCount + 1);
            array[offset + oldCount] = new NamedProperty(KnownProperties.Time, DateTime.Now);
            _logger.UncheckedWrite(level, text, newAttachedProperties, userProperties);
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public bool IsEnabled(Level level)
        {
            return _logger.IsEnabled(level);
        }

        public bool Equals(TimeLogger<TLogger> other)
        {
            return EqualityComparer<TLogger>.Default.Equals(_logger, other._logger);
        }

        public override bool Equals(object obj)
        {
            return obj is TimeLogger<TLogger> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TLogger>.Default.GetHashCode(_logger);
        }

        public static bool operator ==(TimeLogger<TLogger> left, TimeLogger<TLogger> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimeLogger<TLogger> left, TimeLogger<TLogger> right)
        {
            return !left.Equals(right);
        }
    }
}
