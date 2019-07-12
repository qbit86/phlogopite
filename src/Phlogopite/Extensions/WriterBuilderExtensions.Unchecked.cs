using System;
using System.Buffers;

namespace Phlogopite.Extensions
{
    public static partial class WriterBuilderExtensions
    {
        private static void WriteUnchecked(WriterBuilder writer, Level level, string text,
            in NamedProperty p0,
            string source)
        {
            const int userPropertyCount = 1;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount), source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked(WriterBuilder writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1,
            string source)
        {
            const int userPropertyCount = 2;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount), source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked(WriterBuilder writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            string source)
        {
            const int userPropertyCount = 3;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + GetAttachedPropertyCountOrDefault(writer, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                writer.UncheckedWrite(level, text,
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount), source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static void WriteUnchecked(WriterBuilder writer, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            string source)
        {
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
                    properties.AsSpan(0, userPropertyCount), properties.AsSpan(userPropertyCount), source);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
