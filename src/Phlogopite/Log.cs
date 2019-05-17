using System;
using System.Buffers;
using System.Runtime.CompilerServices;

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

        public static void Write(Level level, string tag, string text,
            [CallerMemberName] string source = null)
        {
            if (!Mediator.IsEnabled(level))
                return;

            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(2);
            try
            {
                properties[0] = new NamedProperty("tag", tag);
                properties[1] = new NamedProperty("source", source);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 2);
                Mediator.Write(level, text, default, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
