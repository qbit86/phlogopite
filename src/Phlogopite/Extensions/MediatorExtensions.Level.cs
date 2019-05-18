using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class MediatorExtensions
    {
        #region Verbose

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(mediator, Level.Verbose, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Verbose

        #region Debug

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(mediator, Level.Debug, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Debug

        #region Info

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Info))
                return;

            WriteUnchecked(mediator, Level.Info, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Info

        #region Warning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(mediator, Level.Warning, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Warning

        #region Error

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Error))
                return;

            WriteUnchecked(mediator, Level.Error, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Error

        #region Assert

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this IMediator<NamedProperty> mediator, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (mediator is null || !mediator.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(mediator, Level.Assert, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Assert
    }
}
