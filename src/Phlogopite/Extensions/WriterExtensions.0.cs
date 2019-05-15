namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        public static void Write<TWriter>(this TWriter writer, Level level, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(level, text, default);
        }

        public static void V<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Verbose, text, default);
        }

        public static void D<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Debug, text, default);
        }

        public static void I<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Info, text, default);
        }

        public static void W<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Warning, text, default);
        }

        public static void E<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Error, text, default);
        }

        public static void A<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Assert, text, default);
        }
    }
}
