using System.Runtime.CompilerServices;
using Phlogopite.Extensions;

namespace Phlogopite
{
    public static partial class Log
    {
        #region Verbose

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Verbose))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Verbose, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Verbose

        #region Debug

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Debug))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Debug, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Debug

        #region Info

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Info))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Info, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Info

        #region Warning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Warning))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Warning, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Warning

        #region Error

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Error))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Error, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Error

        #region Assert

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(Level.Assert))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, Level.Assert, tag, text, p0, p1, p2, p3, source);
        }

        #endregion // Assert
    }
}
