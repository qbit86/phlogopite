using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class MediatorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, text, source);
        }
    }
}
