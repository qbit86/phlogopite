using System;

namespace Phlogopite.Singletons.Logger
{
    using PropertyCollection = SpanBuilder<NamedProperty>;

    public static class Log
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
    }
}
