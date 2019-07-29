using System.Runtime.CompilerServices;
using Phlogopite.Extensions.Tag;

namespace Phlogopite.Singletons
{
    public static partial class Log
    {
        #region Verbose

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Verbose, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Verbose, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Verbose, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Verbose, category, text, p0, p1, p2, p3, source);
        }

        #endregion Verbose

        #region Debug

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Debug, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Debug, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Debug, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Debug, category, text, p0, p1, p2, p3, source);
        }

        #endregion Debug

        #region Info

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Info, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Info, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Info, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Info, category, text, p0, p1, p2, p3, source);
        }

        #endregion Info

        #region Warning

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Warning, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Warning, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Warning, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Warning, category, text, p0, p1, p2, p3, source);
        }

        #endregion Warning

        #region Error

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Error, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Error, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Error, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Error, category, text, p0, p1, p2, p3, source);
        }

        #endregion Error

        #region Assert

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Assert, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Assert, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Assert, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Assert, category, text, p0, p1, p2, p3, source);
        }

        #endregion Assert
    }
}
