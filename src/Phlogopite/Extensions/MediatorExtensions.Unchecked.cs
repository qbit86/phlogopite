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
                userPropertyCount + WriterPropertyCount + GetAttachedPropertyCountOrDefault(mediator, level));
            try
            {
                properties[0] = p0;
                Span<NamedProperty> writerProperties = properties.AsSpan(userPropertyCount, WriterPropertyCount);
                writerProperties[0] = new NamedProperty("tag", tag);
                writerProperties[1] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
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
                userPropertyCount + WriterPropertyCount + GetAttachedPropertyCountOrDefault(mediator, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                Span<NamedProperty> writerProperties = properties.AsSpan(userPropertyCount, WriterPropertyCount);
                writerProperties[0] = new NamedProperty("tag", tag);
                writerProperties[1] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
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
                userPropertyCount + WriterPropertyCount + GetAttachedPropertyCountOrDefault(mediator, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                Span<NamedProperty> writerProperties = properties.AsSpan(userPropertyCount, WriterPropertyCount);
                writerProperties[0] = new NamedProperty("tag", tag);
                writerProperties[1] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
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
                userPropertyCount + WriterPropertyCount + GetAttachedPropertyCountOrDefault(mediator, level));
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = p2;
                properties[3] = p3;
                Span<NamedProperty> writerProperties = properties.AsSpan(userPropertyCount, WriterPropertyCount);
                writerProperties[0] = new NamedProperty("tag", tag);
                writerProperties[1] = new NamedProperty("source", source);
                ReadOnlySpan<NamedProperty> userProperties = properties.AsSpan(0, userPropertyCount);
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
