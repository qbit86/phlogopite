using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(Level.Error))
                return;

            writer.UncheckedWrite(level, text, default, default);
        }

        private static int GetAttachedPropertyCountOrDefault<TWriter>(TWriter writer, Level level)
            where TWriter : IWriter<NamedProperty>
        {
            Debug.Assert(writer != null, "writer != null");
            return Math.Max(0, writer.GetAttachedPropertyCount(level));
        }
    }
}
