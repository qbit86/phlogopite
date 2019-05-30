using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class MediatorExtensions
    {
        private const int WriterPropertyCount = 2;

        internal static void WriteUnchecked(IMediator<NamedProperty> mediator, Level level, string tag, string text,
            [CallerMemberName] string source = null)
        {
            Debug.Assert(mediator != null, "mediator != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                WriterPropertyCount + GetAttachedPropertyCountOrDefault(mediator, level));
            try
            {
                properties[0] = new NamedProperty("tag", tag);
                properties[1] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> writerProperties = properties.AsSpan(0, WriterPropertyCount);
                Span<NamedProperty> mediatorProperties = properties.AsSpan(WriterPropertyCount);
                mediator.UncheckedWrite(level, text, default, writerProperties, mediatorProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        private static int GetAttachedPropertyCountOrDefault(IMediator<NamedProperty> mediator, Level level)
        {
            Debug.Assert(mediator != null, "mediator != null");
            return Math.Max(0, mediator.GetAttachedPropertyCount(level));
        }
    }
}
