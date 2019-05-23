using System;
using System.Buffers;
using System.Diagnostics;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        private static void WriteUnchecked<TWriter>(in TWriter writer, Level level, string text,
            in NamedProperty p0)
            where TWriter : IWriter<NamedProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(1 + 2);
            try
            {
                properties[0] = p0;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 1), properties.AsSpan(1));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked<TWriter>(in TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1)
            where TWriter : IWriter<NamedProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(2 + 2);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 2), properties.AsSpan(2));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked<TWriter>(in TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TWriter : IWriter<NamedProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(3 + 2);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 3), properties.AsSpan(3));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked<TWriter>(in TWriter writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TWriter : IWriter<NamedProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(4 + 2);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 4), properties.AsSpan(4));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
