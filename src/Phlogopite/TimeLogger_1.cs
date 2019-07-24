using System;
using System.Collections.Generic;
using Phlogopite.Internal;
using PropertyCollection = Phlogopite.SpanBuilder<Phlogopite.NamedProperty>;

namespace Phlogopite
{
    public static class TimeLogger
    {
        public static TimeLogger<TLogger> Create<TLogger>(TLogger logger)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            return new TimeLogger<TLogger>(logger);
        }
    }

    public readonly struct TimeLogger<TLogger> : ILogger<NamedProperty, PropertyCollection>,
        IEquatable<TimeLogger<TLogger>>
        where TLogger : ILogger<NamedProperty, PropertyCollection>
    {
        private readonly TLogger _logger;

        public TimeLogger(TLogger logger)
        {
            if (logger is null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
        }

        public int MaxAttachedPropertyCount => 1 + _logger.MaxAttachedPropertyCount;

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            PropertyCollection attachedProperties)
        {
            CollectionHelpers.TryAppend(ref attachedProperties, new NamedProperty(KnownProperties.Time, DateTime.Now));
            _logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }

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
