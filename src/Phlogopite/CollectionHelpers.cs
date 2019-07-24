namespace Phlogopite
{
    internal static class CollectionHelpers
    {
        internal static bool TryAppend<T>(ref SpanBuilder<T> collection, T item)
        {
            T[] array = collection.Array;
            int offset = collection.Offset;
            int oldCount = collection.Count;

            if (array is null || offset + oldCount >= array.Length)
                return false;

            array[offset + oldCount] = item;
            collection = new SpanBuilder<T>(array, offset, oldCount + 1);
            return true;
        }
    }
}
