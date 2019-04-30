using System;
using System.Buffers;

namespace Phlogopite
{
    public static partial class WriterExtensions
    {
        public static void Write<TWriter>(this TWriter writer, Level level, string text, in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0);
        }

        public static void V<TWriter>(this TWriter writer, string text, in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0);
        }

        public static void D<TWriter>(this TWriter writer, string text, in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0);
        }

        public static void I<TWriter>(this TWriter writer, string text, NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0);
        }

        public static void W<TWriter>(this TWriter writer, string text, in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            WriteUnchecked(writer, Level.Warning, text, p0);
        }

        public static void E<TWriter>(this TWriter writer, string text, in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, text, p0);
        }

        public static void F<TWriter>(this TWriter writer, string text, in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Fatal))
                return;

            WriteUnchecked(writer, Level.Fatal, text, p0);
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(1);
            try
            {
                properties[0] = p0;
                writer.Write(level, text, properties.AsSpan(0, 1));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }
    }
}