using System;
using System.Buffers;
using System.Diagnostics;
using PropertyCollection = Phlogopite.SpanBuilder<Phlogopite.NamedProperty>;

namespace Phlogopite.Extensions.Source
{
    public static partial class SourceLoggerExtensions
    {
        private static void AllocateThenWrite1<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0,
            string source)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 1;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount + 1);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                userProperties[0] = p0;
                var attachedProperties = new PropertyCollection(properties, userPropertyCount, 0);
                AppendThenWrite(logger, level, text, userProperties, attachedProperties, source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void AllocateThenWrite2<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1,
            string source)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 2;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount + 1);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                userProperties[0] = p0;
                userProperties[1] = p1;
                var attachedProperties = new PropertyCollection(properties, userPropertyCount, 0);
                AppendThenWrite(logger, level, text, userProperties, attachedProperties, source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void AllocateThenWrite3<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            string source)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 3;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount + 1);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                userProperties[0] = p0;
                userProperties[1] = p1;
                userProperties[2] = p2;
                var attachedProperties = new PropertyCollection(properties, userPropertyCount, 0);
                AppendThenWrite(logger, level, text, userProperties, attachedProperties, source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void AllocateThenWrite4<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            string source)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 4;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount + 1);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                userProperties[0] = p0;
                userProperties[1] = p1;
                userProperties[2] = p2;
                userProperties[3] = p3;
                var attachedProperties = new PropertyCollection(properties, userPropertyCount, 0);
                AppendThenWrite(logger, level, text, userProperties, attachedProperties, source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
