using System.Runtime.CompilerServices;

namespace Phlogopite
{
    public static partial class Log
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string tag, string text, [CallerMemberName] string source = null)
        {
            Write(Level.Verbose, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string tag, string text, [CallerMemberName] string source = null)
        {
            Write(Level.Debug, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string tag, string text, [CallerMemberName] string source = null)
        {
            Write(Level.Info, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string tag, string text, [CallerMemberName] string source = null)
        {
            Write(Level.Warning, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string tag, string text, [CallerMemberName] string source = null)
        {
            Write(Level.Error, tag, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string tag, string text, [CallerMemberName] string source = null)
        {
            Write(Level.Assert, tag, text, source);
        }
    }
}
