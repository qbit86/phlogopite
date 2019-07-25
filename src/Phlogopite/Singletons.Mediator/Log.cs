using System;
using System.Runtime.CompilerServices;
using Phlogopite.Extensions.Tag;
using PropertyCollection = Phlogopite.SpanBuilder<Phlogopite.NamedProperty>;

namespace Phlogopite.Singletons.Mediator
{
    public static partial class Log
    {
        private static MediatorLogger s_logger;

        public static MediatorLogger Logger => s_logger ?? MediatorLogger.Silent;

        public static bool TrySetLogger(MediatorLogger logger)
        {
            if (s_logger != null)
                return false;

            s_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, source);
        }
    }
}
