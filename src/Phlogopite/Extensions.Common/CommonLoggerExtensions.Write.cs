using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Common
{
    public static partial class CommonLoggerExtensions
    {
        #region Omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite1(logger, level, null, p0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite2(logger, level, null, p0, p1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite3(logger, level, null, p0, p1, p2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite4(logger, level, null, p0, p1, p2, p3);
        }

        #endregion Omitting text

        #region Including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite1(logger, level, text, p0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite2(logger, level, text, p0, p1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite3(logger, level, text, p0, p1, p2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite4(logger, level, text, p0, p1, p2, p3);
        }

        #endregion Including text
    }
}
