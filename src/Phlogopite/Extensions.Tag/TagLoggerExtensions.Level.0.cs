using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Tag
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public static partial class TagLoggerExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite0(logger, Level.Verbose, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite0(logger, Level.Debug, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite0(logger, Level.Info, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite0(logger, Level.Warning, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite0(logger, Level.Error, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite0(logger, Level.Assert, category, text, source);
        }
    }
}
