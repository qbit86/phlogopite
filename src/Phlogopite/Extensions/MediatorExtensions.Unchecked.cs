using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions
{
    public static partial class MediatorExtensions
    {
        internal static void WriteUnchecked(IMediator<NamedProperty> mediator, Level level, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Debug.Assert(mediator != null, "mediator != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(3);
            try
            {
                properties[0] = p0;
                properties[1] = new NamedProperty("tag", tag);
                properties[2] = new NamedProperty("source", source);
                var userProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 1);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 1, 2);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        internal static void WriteUnchecked(IMediator<NamedProperty> mediator, Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Debug.Assert(mediator != null, "mediator != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(4);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = new NamedProperty("tag", tag);
                properties[3] = new NamedProperty("source", source);
                var userProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 2);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 2, 2);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        internal static void WriteUnchecked(IMediator<NamedProperty> mediator, Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Debug.Assert(mediator != null, "mediator != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(5);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = new NamedProperty("tag", tag);
                properties[4] = new NamedProperty("source", source);
                var userProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 3);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 3, 2);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        internal static void WriteUnchecked(IMediator<NamedProperty> mediator, Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Debug.Assert(mediator != null, "mediator != null");
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(6);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                properties[4] = new NamedProperty("tag", tag);
                properties[5] = new NamedProperty("source", source);
                var userProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 4);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 4, 2);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
