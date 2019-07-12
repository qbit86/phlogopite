using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterBuilderExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, p2, p3, source);
        }
    }
}
