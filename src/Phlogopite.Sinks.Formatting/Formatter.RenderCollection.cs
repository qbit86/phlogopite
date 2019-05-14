using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public sealed partial class Formatter
    {
        private static void RenderCollection(ICollection collection, StringBuilderFacade sbf)
        {
            Debug.Assert(collection != null, "collection != null");
            if (collection.Count == 0)
            {
                sbf.Append("[]");
                return;
            }

            if (collection is IReadOnlyList<string> list)
                RenderReadOnlyList(list, sbf);
            else
                sbf.Append(collection);
        }
    }
}
