using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer.IsEnabled(Level.Verbose))
                writer.UncheckedWrite(Level.Verbose, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer.IsEnabled(Level.Debug))
                writer.UncheckedWrite(Level.Debug, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer.IsEnabled(Level.Info))
                writer.UncheckedWrite(Level.Info, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer.IsEnabled(Level.Warning))
                writer.UncheckedWrite(Level.Warning, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer.IsEnabled(Level.Error))
                writer.UncheckedWrite(Level.Error, text, default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A<TWriter>(this TWriter writer, string text)
            where TWriter : IWriter<NamedProperty>
        {
            if (writer.IsEnabled(Level.Assert))
                writer.UncheckedWrite(Level.Assert, text, default);
        }
    }
}
