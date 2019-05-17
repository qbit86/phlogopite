namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0);
        }

        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1);
        }

        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, p2);
        }

        public static void Write<TWriter>(this TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0, p1, p2, p3);
        }
    }
}
