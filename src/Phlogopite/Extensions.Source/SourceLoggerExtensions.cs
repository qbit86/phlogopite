using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Phlogopite.Internal;

namespace Phlogopite.Extensions.Source
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public static partial class SourceLoggerExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, SpanBuilder<NamedProperty> attachedProperties,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AppendThenWrite(logger, level, text, userProperties, attachedProperties, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite0(logger, level, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetAttachedPropertyCountOrDefault<TLogger>(TLogger logger)
            where TLogger : ILogger<NamedProperty>
        {
            Debug.Assert(logger != null, "logger != null");

            return Math.Max(0, logger.MaxAttachedPropertyCount);
        }

        private static void AllocateThenWrite0<TLogger>(TLogger logger, Level level, string text,
            string source)
            where TLogger : ILogger<NamedProperty>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            const int userPropertyCount = 0;
            int attachedPropertyCount = GetAttachedPropertyCountOrDefault(logger);
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + attachedPropertyCount + 1);
            try
            {
                Span<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                var attachedProperties = new PropertyCollection(properties, userPropertyCount, 0);
                AppendThenWrite(logger, level, text, userProperties, attachedProperties, source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void AppendThenWrite<TLogger>(TLogger logger, Level level, string text,
            ReadOnlySpan<NamedProperty> userProperties, PropertyCollection attachedProperties, string source)
            where TLogger : ILogger<NamedProperty>
        {
            Debug.Assert(logger != null, "logger != null");
            Debug.Assert(logger.IsEnabled(level), "logger.IsEnabled(level)");

            if (source != null)
                CollectionHelpers.TryAppend(ref attachedProperties, new NamedProperty(KnownProperties.Source, source));

            logger.UncheckedWrite(level, text, userProperties, attachedProperties);
        }
    }
}
