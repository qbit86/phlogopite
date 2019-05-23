using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        private const int WriterPropertyCount = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TWriter>(this TWriter writer, Level level, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer is null || !writer.IsEnabled(Level.Error))
                return;

            writer.UncheckedWrite(level, text, default, default);
        }
    }
}
