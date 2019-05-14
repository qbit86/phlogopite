namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2, p3);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2, p3, p4);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2, p3, p4, p5);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2, p3, p4, p5, p6);
        }

        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6, in NamedProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2, p3, p4, p5, p6, p7);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2, p3);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2, p3, p4);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2, p3, p4, p5);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2, p3, p4, p5, p6);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6, in NamedProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2, p3, p4, p5, p6, p7);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2, p3);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2, p3, p4);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2, p3, p4, p5);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2, p3, p4, p5, p6);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6, in NamedProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2, p3, p4, p5, p6, p7);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2, p3);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2, p3, p4);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2, p3, p4, p5);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2, p3, p4, p5, p6);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6, in NamedProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2, p3, p4, p5, p6, p7);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2, p3);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2, p3, p4);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2, p3, p4, p5);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2, p3, p4, p5, p6);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6, in NamedProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2, p3, p4, p5, p6, p7);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1, p2);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1, p2, p3);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1, p2, p3, p4);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1, p2, p3, p4, p5);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1, p2, p3, p4, p5, p6);
        }

        public static void A<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            in NamedProperty p4, in NamedProperty p5, in NamedProperty p6, in NamedProperty p7)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            WriteUnchecked(writer, Level.Assert, text, p0, p1, p2, p3, p4, p5, p6, p7);
        }
    }
}
