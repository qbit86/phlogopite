using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class WriterExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void V(this WriterBuilder writer, string text, [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Verbose))
                return;

            writer.UncheckedWrite(Level.Verbose, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void D(this WriterBuilder writer, string text, [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Debug))
                return;

            writer.UncheckedWrite(Level.Debug, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void I(this WriterBuilder writer, string text, [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Info))
                return;

            writer.UncheckedWrite(Level.Info, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void W(this WriterBuilder writer, string text, [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Warning))
                return;

            writer.UncheckedWrite(Level.Warning, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void E(this WriterBuilder writer, string text, [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            writer.UncheckedWrite(Level.Error, text, default, default, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void A(this WriterBuilder writer, string text, [CallerMemberName] string source = null)
        {
            if (!writer.IsEnabled(Level.Assert))
                return;

            writer.UncheckedWrite(Level.Assert, text, default, default, source);
        }
    }
}
