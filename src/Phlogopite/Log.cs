using System;

namespace Phlogopite
{
    public static partial class Log
    {
        private static IMediator<NamedProperty> s_mediator;

        public static IMediator<NamedProperty> Mediator => s_mediator ?? Phlogopite.Mediator.Silent;

        public static bool TrySetMediator(IMediator<NamedProperty> mediator)
        {
            if (s_mediator != null)
                return false;

            s_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            return true;
        }
    }
}
