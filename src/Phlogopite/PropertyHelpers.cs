using System;

namespace Phlogopite
{
    internal static class PropertyHelpers
    {
        internal static bool TryAdd(ref ArraySegment<NamedProperty> properties, NamedProperty property)
        {
            NamedProperty[] array = properties.Array;
            int offset = properties.Offset;
            int oldCount = properties.Count;

            if (array is null || offset + oldCount >= array.Length)
                return false;

            properties = new ArraySegment<NamedProperty>(array, offset, oldCount + 1);
            array[offset + oldCount] = property;
            return true;
        }
    }
}
