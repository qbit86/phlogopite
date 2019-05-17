using System;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            writer.UncheckedWrite(level, text, default);
        }

        public static void Exception<TWriter>(this TWriter writer, Exception ex)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, null, new NamedProperty(null, ex));
        }
    }
}
