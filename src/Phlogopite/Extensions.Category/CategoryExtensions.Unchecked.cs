using System;
using System.Buffers;
using System.Diagnostics;

namespace Phlogopite.Extensions.Category
{
    public static partial class CategoryExtensions
    {
        private static void UncheckedWrite<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0,
            string source)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            throw new NotImplementedException();
        }

        private static void UncheckedWrite<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1,
            string source)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            throw new NotImplementedException();
        }

        private static void UncheckedWrite<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2,
            string source)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            throw new NotImplementedException();
        }

        private static void UncheckedWrite<TLogger>(TLogger logger, Level level, string text,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3,
            string source)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            throw new NotImplementedException();
        }
    }
}
