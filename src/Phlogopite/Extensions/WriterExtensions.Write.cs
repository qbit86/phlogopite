using System;
using System.Buffers;

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

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(2);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                writer.Write(level, text, properties.AsSpan(0, 2));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(3);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                writer.Write(level, text, properties.AsSpan(0, 3));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }

        private static void WriteUnchecked<TWriter, TProperty>(in TWriter writer, Level level, string text,
            in TProperty p0, in TProperty p1, in TProperty p2, in TProperty p3)
            where TWriter : IWriter<TProperty>
        {
            TProperty[] properties = ArrayPool<TProperty>.Shared.Rent(4);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                writer.Write(level, text, properties.AsSpan(0, 4));
            }
            finally
            {
                ArrayPool<TProperty>.Shared.Return(properties);
            }
        }
    }
}
