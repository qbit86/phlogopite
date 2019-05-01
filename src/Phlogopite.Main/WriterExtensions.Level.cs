namespace Phlogopite
{
    public static partial class WriterExtensions
    {
#if false
        public static void V<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;
        }

        public static void F<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Fatal))
                return;
        }

        public static void F<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Fatal))
                return;
        }

        public static void F<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Fatal))
                return;
        }

        public static void F<TWriter>(this TWriter writer, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Fatal))
                return;
        }
#endif
    }
}
