using System;
using System.Runtime.CompilerServices;

namespace Phlogopite.Extensions.Category
{
    public static partial class CategoryExtensions
    {
        #region Omitting text

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Write<TLogger>(this TLogger logger, Level level,
            in NamedProperty p0, in NamedProperty p1, in NamedProperty p2, in NamedProperty p3)
            where TLogger : ILogger<NamedProperty, ArraySegment<NamedProperty>>
        {
            if (logger is null || !logger.IsEnabled(Level.Error))
                return;

            throw new NotImplementedException();
        }

        #endregion Omitting text

        #region Including text

        #endregion Including text
    }
}
