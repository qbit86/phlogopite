using System;
using System.Buffers;

namespace Phlogopite
{
    public static partial class WriterExtensions
    {
        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(5);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                properties[4] = p4;
                writer.Write(level, text, properties.AsSpan(0, 5));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(6);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                properties[4] = p4;
                properties[5] = p5;
                writer.Write(level, text, properties.AsSpan(0, 6));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(7);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                properties[4] = p4;
                properties[5] = p5;
                properties[6] = p6;
                writer.Write(level, text, properties.AsSpan(0, 7));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3,
            in TProperty p4, in TProperty p5, in TProperty p6, in TProperty p7)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(8);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                properties[4] = p4;
                properties[5] = p5;
                properties[6] = p6;
                properties[7] = p7;
                writer.Write(level, text, properties.AsSpan(0, 8));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }
    }
}
