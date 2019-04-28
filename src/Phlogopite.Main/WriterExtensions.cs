using System;
using System.Buffers;

namespace Phlogopite
{
    public static class WriterExtensions
    {
        public static void Write(this Writer writer, Level level, string text, in NamedProperty p0)
        {
            if (!writer.IsEnabled(level))
                return;

            WriteUnchecked(writer, level, text, p0);
        }

        public static void V(this Writer writer, string text, in NamedProperty p0)
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            WriteUnchecked(writer, Level.Verbose, text, p0);
        }

        public static void D(this Writer writer, string text, in NamedProperty p0)
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            WriteUnchecked(writer, Level.Debug, text, p0);
        }

        public static void I(this Writer writer, string text, NamedProperty p0)
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            WriteUnchecked(writer, Level.Info, text, p0);
        }

        private static void WriteUnchecked(in Writer writer, Level level, string text, in NamedProperty p0)
        {
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(1);
            try
            {
                properties[0] = p0;
                writer.Write(level, text, properties.AsSpan(0, 1));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties);
            }
        }
    }
}
