using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    internal static class RenderingHelpers
    {
        internal static void RenderCollection(ICollection collection, StringBuilderFacade sbf)
        {
            Debug.Assert(collection != null, "collection != null");
            if (collection.Count == 0)
            {
                sbf.Append("[]");
                return;
            }

            if (collection is IReadOnlyList<string> stringList)
                RenderReadOnlyList(stringList, sbf);
            else if (collection is IReadOnlyList<int> intList)
                RenderReadOnlyList(intList, sbf);
            else if (collection is IReadOnlyList<byte> byteList)
                RenderReadOnlyList(byteList, sbf);
            else if (collection is IReadOnlyList<double> doubleList)
                RenderReadOnlyList(doubleList, sbf);
            else if (collection is IReadOnlyList<long> longList)
                RenderReadOnlyList(longList, sbf);
            else if (collection is IReadOnlyList<float> floatList)
                RenderReadOnlyList(floatList, sbf);
            else if (collection is IReadOnlyList<DateTime> dateTimeList)
                RenderReadOnlyList(dateTimeList, sbf);
            else if (collection is IReadOnlyList<bool> boolList)
                RenderReadOnlyList(boolList, sbf);
            else if (collection is IReadOnlyList<char> charList)
                RenderReadOnlyList(charList, sbf);
            else if (collection is IReadOnlyList<sbyte> sbyteList)
                RenderReadOnlyList(sbyteList, sbf);
            else if (collection is IReadOnlyList<short> shortList)
                RenderReadOnlyList(shortList, sbf);
            else if (collection is IReadOnlyList<ushort> ushortList)
                RenderReadOnlyList(ushortList, sbf);
            else if (collection is IReadOnlyList<uint> uintList)
                RenderReadOnlyList(uintList, sbf);
            else if (collection is IReadOnlyList<ulong> ulongList)
                RenderReadOnlyList(ulongList, sbf);
            else if (collection is IReadOnlyList<object> objectList)
                RenderReadOnlyList(objectList, sbf);
            else
                sbf.Append(collection);
        }

        private static void RenderReadOnlyList(IReadOnlyList<string> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<int> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<byte> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<double> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<long> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<float> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<DateTime> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<bool> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<char> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<sbyte> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<short> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<ushort> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<uint> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<ulong> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }

        private static void RenderReadOnlyList(IReadOnlyList<object> values, StringBuilderFacade sbf)
        {
            Debug.Assert(values != null, "values != null");

            sbf.Append("[");
            for (int i = 0; i < values.Count; ++i)
            {
                if (i != 0)
                    sbf.Append(", ");

                sbf.Append(values[i]);
            }

            sbf.Append("]");
        }
    }
}
