using System;

namespace Phlogopite.Singletons.Mediator
{
    public static class Log
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
    }
}
