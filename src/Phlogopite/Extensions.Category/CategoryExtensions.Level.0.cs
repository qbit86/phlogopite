using System;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Category
{
    public static partial class CategoryExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Verbose))
                return;

            AppendThenWrite(logger, Level.Verbose, category, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Debug))
                return;

            AppendThenWrite(logger, Level.Debug, category, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Info))
                return;

            AppendThenWrite(logger, Level.Info, category, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Warning))
                return;

            AppendThenWrite(logger, Level.Warning, category, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            AppendThenWrite(logger, Level.Error, category, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TLogger>(this TLogger logger, string category, string text,
            [CallerMemberName] string source = null)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Assert))
                return;

            AppendThenWrite(logger, Level.Assert, category, text, default, default, source);
        }
    }
}
