using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, p1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, p1, p2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, null, p0, p1, p2, p3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, p2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, p2, p3);
        }
    }
}
