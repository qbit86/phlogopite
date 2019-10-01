using System;
using System.Collections;
using System.Diagnostics;
using Phlogopite;

namespace Samples
{
    internal static class RenderingHelpers
    {
        internal static void RenderValue(in NamedProperty p, StringBuilderFacade sbf)
        {
            switch (p.TypeCode)
            {
                case TypeCode.Empty:
                    return;
                case TypeCode.Boolean:
                    sbf.Append(p.AsBoolean);
                    return;
                case TypeCode.Char:
                    sbf.Append(p.AsChar);
                    return;
                case TypeCode.SByte:
                    sbf.Append(p.AsSByte, "x2");
                    return;
                case TypeCode.Byte:
                    sbf.Append(p.AsByte, "x2");
                    return;
                case TypeCode.Int16:
                    sbf.Append(p.AsInt16);
                    return;
                case TypeCode.UInt16:
                    sbf.Append(p.AsUInt16);
                    return;
                case TypeCode.Int32:
                    sbf.Append(p.AsInt32);
                    return;
                case TypeCode.UInt32:
                    sbf.Append(p.AsUInt32);
                    return;
                case TypeCode.Int64:
                    sbf.Append(p.AsInt64);
                    return;
                case TypeCode.UInt64:
                    sbf.Append(p.AsUInt64);
                    return;
                case TypeCode.Single:
                    sbf.Append(p.AsSingle);
                    return;
                case TypeCode.Double:
                    sbf.Append(p.AsDouble);
                    return;
                case TypeCode.DateTime:
                    sbf.Append(p.AsDateTime);
                    return;
                case TypeCode.String:
                    sbf.Append(p.AsString);
                    return;
                case TypeCode.Object:
                    RenderObject(p.AsObject, sbf);
                    return;
                default:
                    sbf.Append(p.AsObject);
                    return;
            }
        }

        private static void RenderObject(object o, StringBuilderFacade sbf)
        {
            if (o is ICollection collection)
                RenderCollection(collection, sbf);
            else
                sbf.Append(o);
        }

        private static void RenderCollection(ICollection collection, StringBuilderFacade sbf)
        {
            Debug.Assert(collection != null, "collection != null");
            if (collection.Count == 0)
            {
                sbf.Append("[]");
                return;
            }

            sbf.Append("[");
            sbf.Append(string.Join(", ", collection));
            sbf.Append("]");
        }
    }
}
