using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class MediatorExtensions
    {
        internal static void WriteUnchecked(IMediator<NamedProperty> mediator, Level level, string tag, string text,
            [CallerMemberName] string source = null)
        {
            Debug.Assert(mediator != null, "mediator != null");

            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(2);
            try
            {
                properties[0] = new NamedProperty("tag", tag);
                properties[1] = new NamedProperty("source", source);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 2);
                mediator.UncheckedWrite(level, text, default, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
