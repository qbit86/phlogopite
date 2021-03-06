using System;
using System.Runtime.CompilerServices;
using Phlogopite.Extensions.Tag;

namespace Phlogopite.Singletons
{
    public static partial class Log
    {
        private static ILogger<NamedProperty> s_logger;

        public static ILogger<NamedProperty> Logger => s_logger ?? SilentLogger.Default;

        public static bool TrySetLogger(ILogger<NamedProperty> logger)
        {
            if (s_logger != null)
                return false;

            s_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            ReadOnlySpan<NamedProperty> userProperties, SpanBuilder<NamedProperty> attachedProperties,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, userProperties, attachedProperties, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string category, string text,
            [CallerMemberName] string source = null)
        {
            Logger.Write(level, category, text, source);
        }
    }
}
