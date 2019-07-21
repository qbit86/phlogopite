using System;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Source
{
    public static partial class SourceLoggerExtensions
    {
        #region Omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite1(logger, level, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite2(logger, level, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite3(logger, level, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite4(logger, level, null, p0, p1, p2, p3, source);
        }

        #endregion Omitting text

        #region Including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite1(logger, level, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite2(logger, level, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite3(logger, level, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(level))
                return;

            AllocateThenWrite4(logger, level, text, p0, p1, p2, p3, source);
        }

        #endregion Including text
    }
}
