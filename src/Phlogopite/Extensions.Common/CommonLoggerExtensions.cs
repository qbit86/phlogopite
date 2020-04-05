using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Common
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public static partial class CommonLoggerExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, SpanBuilder<NamedProperty> attachedProperties)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite0(logger, level, text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetAttachedPropertyCountOrDefault<TLogger>(TLogger logger)
            where TLogger : ILogger<NamedProperty>
        {
            Debug.Assert(logger != null, "logger != null");

            return Math.Max(0, logger.GetMaxAttachedPropertyCount());
        }

        private static void AllocateThenWrite0<TLogger>(TLogger logger, Level level, string text)
            where TLogger : ILogger<NamedProperty>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 0;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                var attachedProperties = new PropertyCollection(properties.AsSpan(userPropertyCount));
                logger.UncheckedWrite(level, text, userProperties, attachedProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
