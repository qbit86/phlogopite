using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Verbose, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Debug, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Info, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Warning, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Error, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            writer.Write(Level.Assert, text, default);
        }
    }
}
