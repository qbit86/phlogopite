using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using Phlogopite.Extensions;

namespace Phlogopite
{
    public static partial class Log
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, null, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, text, p0, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, null, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, text, p0, p1, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, null, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, text, p0, p1, p2, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, null, p0, p1, p2, p3, source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write(Level level, string tag, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            [CallerMemberName] string source = null)
        {
            if (s_mediator is null || !s_mediator.IsEnabled(level))
                return;

            MediatorExtensions.WriteUnchecked(s_mediator, level, tag, text, p0, p1, p2, p3, source);
        }
    }
}
