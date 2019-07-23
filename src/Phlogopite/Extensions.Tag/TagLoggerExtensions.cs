using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PropertyCollection = System.ArraySegment<Phlogopite.NamedProperty>;

namespace Phlogopite.Extensions.Tag
{
    public static partial class TagLoggerExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite0(logger, level, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetAttachedPropertyCountOrDefault<TLogger>(TLogger logger)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");

            return Math.Max(0, logger.MaxAttachedPropertyCount);
        }

        private static void AllocateThenWrite0<TLogger>(TLogger logger, Level level, string category, string text,
            string source)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 0;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount + 2);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                var attachedProperties = new PropertyCollection(properties, userPropertyCount, 0);
                AppendThenWrite(logger, level, category, text, attachedProperties, userProperties, source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void AppendThenWrite<TLogger>(TLogger logger, Level level, string category, string text,
            PropertyCollection attachedProperties, ReadOnlySpan<NamedProperty> userProperties, string source)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            if (category != null && !CollectionHelpers.TryAppend(ref attachedProperties,
                new NamedProperty(KnownProperties.Category, category)))
            {
                logger.UncheckedWrite(level, text, userProperties, attachedProperties);
                return;
            }

            if (source != null)
                CollectionHelpers.TryAppend(ref attachedProperties, new NamedProperty(KnownProperties.Source, source));

            logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }
    }
}
