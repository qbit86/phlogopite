using System.Buffers;
using System.Runtime.CompilerServices;

namespace Phlogopite
{
    public static partial class Log
    {
        public static void Write(Level level, string tag, string text,
            in NamedProperty p0,
            [CallerMemberName] string source = null)
        {
            if (!Mediator.IsEnabled(level))
                return;

            NamedProperty[] properties = ArrayPool<NamedProperty>.Shared.Rent(3);
            try
            {
                throw new System.NotImplementedException();
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
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
                throw new System.NotImplementedException();
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
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
                throw new System.NotImplementedException();
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
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
                throw new System.NotImplementedException();
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(properties, true);
            }
        }
    }
}
