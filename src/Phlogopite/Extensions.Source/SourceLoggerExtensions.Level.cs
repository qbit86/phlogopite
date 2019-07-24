using System.Runtime.CompilerServices;
using PropertyCollection = Phlogopite.SpanBuilder<Phlogopite.NamedProperty>;

namespace Phlogopite.Extensions.Source
{
    public static partial class SourceLoggerExtensions
    {
        #region Verbose, omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite1(logger, Level.Verbose, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite2(logger, Level.Verbose, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite3(logger, Level.Verbose, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite4(logger, Level.Verbose, null, p0, p1, p2, p3, source);
        }

        #endregion Verbose, omitting text

        #region Verbose, including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite1(logger, Level.Verbose, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite2(logger, Level.Verbose, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite3(logger, Level.Verbose, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite4(logger, Level.Verbose, text, p0, p1, p2, p3, source);
        }

        #endregion Verbose, including text

        #region Debug, omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite1(logger, Level.Debug, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite2(logger, Level.Debug, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite3(logger, Level.Debug, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite4(logger, Level.Debug, null, p0, p1, p2, p3, source);
        }

        #endregion Debug, omitting text

        #region Debug, including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite1(logger, Level.Debug, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite2(logger, Level.Debug, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite3(logger, Level.Debug, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite4(logger, Level.Debug, text, p0, p1, p2, p3, source);
        }

        #endregion Debug, including text

        #region Info, omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite1(logger, Level.Info, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite2(logger, Level.Info, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite3(logger, Level.Info, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite4(logger, Level.Info, null, p0, p1, p2, p3, source);
        }

        #endregion Info, omitting text

        #region Info, including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite1(logger, Level.Info, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite2(logger, Level.Info, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite3(logger, Level.Info, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite4(logger, Level.Info, text, p0, p1, p2, p3, source);
        }

        #endregion Info, including text

        #region Warning, omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite1(logger, Level.Warning, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite2(logger, Level.Warning, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite3(logger, Level.Warning, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite4(logger, Level.Warning, null, p0, p1, p2, p3, source);
        }

        #endregion Warning, omitting text

        #region Warning, including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite1(logger, Level.Warning, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite2(logger, Level.Warning, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite3(logger, Level.Warning, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite4(logger, Level.Warning, text, p0, p1, p2, p3, source);
        }

        #endregion Warning, including text

        #region Error, omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite1(logger, Level.Error, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite2(logger, Level.Error, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite3(logger, Level.Error, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite4(logger, Level.Error, null, p0, p1, p2, p3, source);
        }

        #endregion Error, omitting text

        #region Error, including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite1(logger, Level.Error, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite2(logger, Level.Error, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite3(logger, Level.Error, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite4(logger, Level.Error, text, p0, p1, p2, p3, source);
        }

        #endregion Error, including text

        #region Assert, omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite1(logger, Level.Assert, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite2(logger, Level.Assert, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite3(logger, Level.Assert, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite4(logger, Level.Assert, null, p0, p1, p2, p3, source);
        }

        #endregion Assert, omitting text

        #region Assert, including text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite1(logger, Level.Assert, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite2(logger, Level.Assert, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite3(logger, Level.Assert, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite4(logger, Level.Assert, text, p0, p1, p2, p3, source);
        }

        #endregion Assert, including text
    }
}
