using System.Runtime.CompilerServices;
using PropertyCollection = Phlogopite.SpanBuilder<Phlogopite.NamedProperty>;

namespace Phlogopite.Extensions.Common
{
    public static partial class CommonLoggerExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string text)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AllocateThenWrite0(logger, Level.Verbose, text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string text)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AllocateThenWrite0(logger, Level.Debug, text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string text)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AllocateThenWrite0(logger, Level.Info, text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string text)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AllocateThenWrite0(logger, Level.Warning, text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string text)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AllocateThenWrite0(logger, Level.Error, text);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string text)
            where TLogger : ILogger<NamedProperty, PropertyCollection>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AllocateThenWrite0(logger, Level.Assert, text);
        }
    }
}
