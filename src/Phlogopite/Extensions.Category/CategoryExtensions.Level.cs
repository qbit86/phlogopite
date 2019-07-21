using System;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Tag
{
    public static partial class CategoryExtensions
    {
        #region Verbose

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite1(logger, Level.Verbose, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite2(logger, Level.Verbose, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite3(logger, Level.Verbose, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite4(logger, Level.Verbose, category, text, p0, p1, p2, p3, source);
        }

        #endregion Verbose

        #region Debug

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite1(logger, Level.Debug, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite2(logger, Level.Debug, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite3(logger, Level.Debug, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite4(logger, Level.Debug, category, text, p0, p1, p2, p3, source);
        }

        #endregion Debug

        #region Info

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite1(logger, Level.Info, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite2(logger, Level.Info, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite3(logger, Level.Info, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite4(logger, Level.Info, category, text, p0, p1, p2, p3, source);
        }

        #endregion Info

        #region Warning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite1(logger, Level.Warning, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite2(logger, Level.Warning, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite3(logger, Level.Warning, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite4(logger, Level.Warning, category, text, p0, p1, p2, p3, source);
        }

        #endregion Warning

        #region Error

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite1(logger, Level.Error, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite2(logger, Level.Error, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite3(logger, Level.Error, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite4(logger, Level.Error, category, text, p0, p1, p2, p3, source);
        }

        #endregion Error

        #region Assert

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite1(logger, Level.Assert, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite2(logger, Level.Assert, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite3(logger, Level.Assert, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite4(logger, Level.Assert, category, text, p0, p1, p2, p3, source);
        }

        #endregion Assert
    }
}
