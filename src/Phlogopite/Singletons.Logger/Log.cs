using System;
using PropertyCollection = System.ArraySegment<Phlogopite.NamedProperty>;

namespace Phlogopite.Singletons.Logger
{
    public static class Log
    {
        private static ILogger<NamedProperty, PropertyCollection> s_logger;

        public static ILogger<NamedProperty, PropertyCollection> Logger => s_logger ?? SilentLogger.Default;

        public static bool TrySetLogger(ILogger<NamedProperty, PropertyCollection> logger)
        {
            if (s_logger != null)
                return false;

            s_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return true;
        }
    }
}
