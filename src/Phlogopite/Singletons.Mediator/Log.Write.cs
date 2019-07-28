using System.Runtime.CompilerServices;
using Phlogopite.Extensions.Tag;

namespace Phlogopite.Singletons.Mediator
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public static partial class Log
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, p0, p1, p2, p3, source);
        }
    }
}
