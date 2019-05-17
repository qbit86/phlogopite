using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Phlogopite
{
    public static partial class Log
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            Write(level, tag, null, p0, source);
        }

        public static void Write(Level level, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (!Mediator.IsEnabled(level))
                return;

            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(3);
            try
            {
                properties[0] = p0;
                properties[1] = new NamedProperty("tag", tag);
                properties[2] = new NamedProperty("source", source);
                var userProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 1);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 1, 2);
                Mediator.Write(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            Write(level, tag, null, p0, p1, source);
        }

        public static void Write(Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (!Mediator.IsEnabled(level))
                return;

            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(4);
            try
            {
                properties[0] = p0;
                properties[1] = p1;
                properties[2] = new NamedProperty("tag", tag);
                properties[3] = new NamedProperty("source", source);
                var userProperties = new ReadOnlySpan<NamedProperty>(properties, 0, 2);
                var writerProperties = new ReadOnlySpan<NamedProperty>(properties, 2, 2);
                Mediator.Write(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            Write(level, tag, null, p0, p1, p2, source);
        }

        public static void Write(Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (!Mediator.IsEnabled(level))
                return;

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
                Mediator.Write(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            Write(level, tag, null, p0, p1, p2, p3, source);
        }

        public static void Write(Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (!Mediator.IsEnabled(level))
                return;

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
                Mediator.Write(level, text, userProperties, writerProperties);
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
