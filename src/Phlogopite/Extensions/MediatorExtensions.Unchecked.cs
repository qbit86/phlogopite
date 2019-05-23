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
            const int userPropertyCount = 1;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + WriterPropertyCount + MediatorPropertyCount);
            try
            {
                properties[0] = p0;
                properties[1] = new NamedProperty("tag", tag);
                properties[2] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                ReadOnlySpan<NamedProperty> writerProperties = properties.AsSpan(
                    userPropertyCount, WriterPropertyCount);
                Span<NamedProperty> attachedProperties = properties.AsSpan(userPropertyCount + WriterPropertyCount);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties, attachedProperties);
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
            const int userPropertyCount = 2;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + WriterPropertyCount + MediatorPropertyCount);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = new NamedProperty("tag", tag);
                properties[3] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                ReadOnlySpan<NamedProperty> writerProperties = properties.AsSpan(
                    userPropertyCount, WriterPropertyCount);
                Span<NamedProperty> attachedProperties = properties.AsSpan(userPropertyCount + WriterPropertyCount);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties, attachedProperties);
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
            const int userPropertyCount = 3;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + WriterPropertyCount + MediatorPropertyCount);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = new NamedProperty("tag", tag);
                properties[4] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                ReadOnlySpan<NamedProperty> writerProperties = properties.AsSpan(
                    userPropertyCount, WriterPropertyCount);
                Span<NamedProperty> attachedProperties = properties.AsSpan(userPropertyCount + WriterPropertyCount);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties, attachedProperties);
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
            const int userPropertyCount = 4;
            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(
                userPropertyCount + WriterPropertyCount + MediatorPropertyCount);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                properties[4] = new NamedProperty("tag", tag);
                properties[5] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
                ReadOnlySpan<NamedProperty> writerProperties = properties.AsSpan(
                    userPropertyCount, WriterPropertyCount);
                Span<NamedProperty> attachedProperties = properties.AsSpan(userPropertyCount + WriterPropertyCount);
                mediator.UncheckedWrite(level, text, userProperties, writerProperties, attachedProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
