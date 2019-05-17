using System;
using System.Buffers;
using System.Diagnostics;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0)
            where TWriter : IWriter<TProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(1);
            try
            {
                properties[0] = p0;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 1));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1)
            where TWriter : IWriter<TProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(2);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 2));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2)
            where TWriter : IWriter<TProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(3);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 3));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3)
            where TWriter : IWriter<TProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(4);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                writer.UncheckedWrite(level, text, properties.AsSpan(0, 4));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties, true);
            }
        }
    }
}
