using System;
using System.Buffers;

namespace Phlogopite
{
    public static partial class WriterExtensions
    {
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
    }
}