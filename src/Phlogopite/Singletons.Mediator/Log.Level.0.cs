using System.Runtime.CompilerServices;
using Phlogopite.Extensions.Tag;

namespace Phlogopite.Singletons.Mediator
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public static partial class Log
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Verbose, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Debug, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Info, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Warning, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Error, category, text, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(Level.Assert, category, text, source);
        }
    }
}
