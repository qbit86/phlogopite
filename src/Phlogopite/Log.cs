using System;
using System.Runtime.CompilerServices;
using Phlogopite.Extensions;

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, text, source);
        }
    }
}
