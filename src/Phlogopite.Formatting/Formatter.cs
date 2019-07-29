using System;
using System.Collections;
using System.Text;
using Phlogopite.Internal;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public sealed partial class Formatter : IFormatter<NamedProperty>
    {
        private Formatter() { }

        public static Formatter Default { get; } = new Formatter();

        public void Format(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> attachedProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Range> userRanges,
            Span<Range> attachedRanges)
        {
            if (formatProvider is null)
                throw new ArgumentNullException(nameof(formatProvider));

            if (output is null)
                throw new ArgumentNullException(nameof(output));

            RenderLevel(level, output);

            var sbf = new StringBuilderFacade(output, formatProvider);

            int timeIndex = FindDateTime(attachedProperties, KnownProperties.Time, out DateTime time);
            if (timeIndex >= 0)
            {
                int timeOffset = output.Length;
                output.Append(" ");
                RenderTime(time, sbf);
                SetRange(timeIndex, timeOffset, output, attachedRanges);
            }

            int categoryIndex = FindString(attachedProperties, KnownProperties.Category, out string category);
            int sourceIndex = FindString(attachedProperties, KnownProperties.Source, out string source);
            if (category != null || source != null)
            {
                output.Append(" [");
                if (!string.IsNullOrEmpty(category))
                {
                    int tagOffset = output.Length;
                    output.Append(category);
                    SetRange(categoryIndex, tagOffset, output, attachedRanges);
                }

                if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(source))
                    output.Append(".");

                if (!string.IsNullOrEmpty(source))
                {
                    int sourceOffset = output.Length;
                    output.Append(source);
                    SetRange(sourceIndex, sourceOffset, output, attachedRanges);
                }

                output.Append("]");
            }

            if (!string.IsNullOrEmpty(text))
            {
                output.Append(" ");
                output.Append(text);
            }

            for (int i = 0; i != userProperties.Length; ++i)
            {
                if (i != 0)
                {
                    output.Append(", ");
                    if (!string.IsNullOrEmpty(userProperties[i].Name))
                    {
                        output.Append(userProperties[i].Name);
                        output.Append(": ");
                    }

                    int propertyOffset = output.Length;
                    RenderValue(userProperties[i], sbf);
                    SetRange(i, propertyOffset, output, userRanges);
                    continue;
                }

                if (string.IsNullOrEmpty(text) || char.IsPunctuation(text, text.Length - 1))
                {
                    output.Append(" ");
                    if (!string.IsNullOrEmpty(userProperties[i].Name))
                    {
                        output.Append(userProperties[i].Name);
                        output.Append(": ");
                    }

                    int propertyOffset = output.Length;
                    RenderValue(userProperties[i], sbf);
                    SetRange(i, propertyOffset, output, userRanges);
                    continue;
                }

                if (!string.IsNullOrEmpty(userProperties[i].Name))
                {
                    output.Append(". ");
                    output.Append(userProperties[i].Name);
                }

                {
                    output.Append(": ");
                    int propertyOffset = output.Length;
                    RenderValue(userProperties[i], sbf);
                    SetRange(i, propertyOffset, output, userRanges);
                }
            }
        }

        private static void SetRange(int rangeIndex, int propertyOffset, StringBuilder sb, Span<Range> ranges)
        {
            if ((uint)rangeIndex >= (uint)ranges.Length)
                return;

            ranges[rangeIndex] = new Range(propertyOffset, sb.Length);
        }

        private static int FindDateTime(ReadOnlySpan<NamedProperty> properties, string name, out DateTime value)
        {
            for (int i = 0; i != properties.Length; ++i)
            {
                NamedProperty p = properties[i];

                if (!ReferenceEquals(p.Name, name))
                    continue;

                if (p.TryGetDateTime(out value))
                    return i;
            }

            value = default;
            return -1;
        }

        private static int FindString(ReadOnlySpan<NamedProperty> properties, string name, out string value)
        {
            for (int i = 0; i != properties.Length; ++i)
            {
                NamedProperty p = properties[i];

                if (!ReferenceEquals(p.Name, name))
                    continue;

                if (p.TryGetString(out value))
                    return i;
            }

            value = default;
            return -1;
        }

        private static void RenderLevel(Level level, StringBuilder output)
        {
            switch (level)
            {
                case Level.Verbose:
                    output.Append("V");
                    break;
                case Level.Debug:
                    output.Append("D");
                    break;
                case Level.Info:
                    output.Append("I");
                    break;
                case Level.Warning:
                    output.Append("W");
                    break;
                case Level.Error:
                    output.Append("E");
                    break;
                case Level.Assert:
                    output.Append("A");
                    break;
                default:
                    output.Append("-");
                    break;
            }
        }

        private static void RenderTime(DateTime time, StringBuilderFacade sbf)
        {
            const string format = "HH:mm:ss.fff";
            sbf.Append(time, format);
        }

        private static void RenderValue(in NamedProperty p, StringBuilderFacade sbf)
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
    }
}