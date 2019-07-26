namespace Phlogopite
{
    internal static class CollectionHelpers
    {
        internal static bool TryAppend<T>(ref SpanBuilder<T> collection, T item)
        {
            return collection.TryAppend(item, out collection);
        }
    }
}
