using System;
using System.Buffers;

namespace Phlogopite
{
    public static partial class WriterExtensions
    {
        public static void V<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0, p1, p2, p3);
        }

        public static void D<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0, p1, p2, p3);
        }

        public static void I<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0, p1, p2, p3);
        }

        public static void W<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0, p1, p2, p3);
        }

        public static void E<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0, p1, p2, p3);
        }

        public static void F<TWriter>(this TWriter writer, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Fatal))
                return;

            WriteUnchecked(writer, Level.Fatal, text, p0, p1, p2, p3);
        }
    }
}
