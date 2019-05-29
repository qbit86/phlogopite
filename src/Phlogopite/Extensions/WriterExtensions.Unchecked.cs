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
            const int userPropertyCount = 1;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount));
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
            const int userPropertyCount = 2;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount));
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
            const int userPropertyCount = 3;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount));
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
            const int userPropertyCount = 4;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
