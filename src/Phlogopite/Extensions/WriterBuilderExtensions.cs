using System;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterBuilderExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(this WriterBuilder writer, Level level, string text,
            [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            writer.UncheckedWrite(level, text, default, default, source);
        }

        private static int GetAttachedPropertyCountOrDefault(WriterBuilder writer, Level level)
        {
            return Math.Max(0, writer.GetAttachedPropertyCount(level));
        }
    }
}
