using System;

namespace Phlogopite
{
    public static class Log
    {
        private static ILogger<NamedProperty, ArraySegment<NamedProperty>> s_logger;

        public static ILogger<NamedProperty, ArraySegment<NamedProperty>> Logger => s_logger ?? SilentLogger.Default;

        public static bool TrySetLogger(ILogger<NamedProperty, ArraySegment<NamedProperty>> logger)
        {
            if (s_logger != null)
                return false;

            s_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return true;
        }
    }
}
