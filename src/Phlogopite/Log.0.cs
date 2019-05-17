using System.Runtime.CompilerServices;
using Phlogopite.Extensions;

namespace Phlogopite
{
    public static partial class Log
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag, string text, [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag, string text, [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag, string text, [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag, string text, [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag, string text, [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag, string text, [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, text, source);
        }
    }
}
