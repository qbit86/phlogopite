using System;

namespace Phlogopite
{
    internal static class PropertyCollectionHelpers
    {
        internal static bool TryAdd<T>(ref ArraySegment<T> arraySegment, T item)
        {
            T[] array = arraySegment.Array;
            int offset = arraySegment.Offset;
            int oldCount = arraySegment.Count;

            if (array is null || offset + oldCount >= array.Length)
                return false;

            array[offset + oldCount] = item;
            arraySegment = new ArraySegment<T>(array, offset, oldCount + 1);
            return true;
        }
    }
}
