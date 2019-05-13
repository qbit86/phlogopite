using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Phlogopite
{
    public interface IFormatter<TProperty>
    {
        void Format(Level level, string text, ReadOnlySpan<TProperty> userProperties,
            ReadOnlySpan<TProperty> writerProperties, ReadOnlySpan<TProperty> mediatorProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Segment> userSegments,
            Span<Segment> writerSegments, Span<Segment> mediatorSegments);
    }

    public sealed class Formatter : IFormatter<NamedProperty>
    {
        private Formatter() { }

        public static Formatter Default { get; } = new Formatter();

        public void Format(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            IFormatProvider formatProvider, StringBuilder output, Span<Segment> userSegments,
            Span<Segment> writerSegments, Span<Segment> mediatorSegments)
        {
            if (formatProvider == null)
                throw new ArgumentNullException(nameof(formatProvider));

            if (output == null)
                throw new ArgumentNullException(nameof(output));

            RenderLevel(level, output);
            output.Append(" ");

            var sbf = new StringBuilderFacade(output, formatProvider);

            int timeIndex = FindDateTime(mediatorProperties, "time", out DateTime time);
            if (timeIndex >= 0)
            {
                int timeOffset = output.Length;
                RenderTime(time, sbf);
                TrySetSegment(timeIndex, timeOffset, output, mediatorSegments);
            }
            else
            {
                output.Append("            ");
            }

            output.Append(" ");

            int tagIndex = FindString(writerProperties, "tag", out string tag);
            int sourceIndex = FindString(writerProperties, "source", out string source);
            if (tag != null || source != null)
            {
                output.Append("[");
                if (!string.IsNullOrEmpty(tag))
                {
                    int tagOffset = output.Length;
                    output.Append(tag);
                    TrySetSegment(tagIndex, tagOffset, output, writerSegments);
                }

                if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(source))
                    output.Append(".");

                if (!string.IsNullOrEmpty(source))
                {
                    int sourceOffset = output.Length;
                    output.Append(source);
                    TrySetSegment(sourceIndex, sourceOffset, output, writerSegments);
                }

                output.Append("] ");
            }

            output.Append(text);

            for (int i = 0; i != userProperties.Length; ++i)
            {
                if (i == 0 && !string.IsNullOrEmpty(text))
                {
                    bool endsWithPunctuation = char.IsPunctuation(text, text.Length - 1);
                    if (endsWithPunctuation)
                    {
                        output.Append(" ");
                        if (!string.IsNullOrEmpty(userProperties[i].Name))
                        {
                            output.Append(userProperties[i].Name);
                            output.Append(": ");
                        }

                        int propertyOffset = output.Length;
                        RenderValue(userProperties[i], sbf);
                        TrySetSegment(i, propertyOffset, output, userSegments);
                    }
                    else if (string.IsNullOrEmpty(userProperties[i].Name))
                    {
                        output.Append(": ");
                        int propertyOffset = output.Length;
                        RenderValue(userProperties[i], sbf);
                        TrySetSegment(i, propertyOffset, output, userSegments);
                    }
                    else
                    {
                        output.Append(". ");
                        output.Append(userProperties[i].Name);
                        output.Append(": ");
                        int propertyOffset = output.Length;
                        RenderValue(userProperties[i], sbf);
                        TrySetSegment(i, propertyOffset, output, userSegments);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(userProperties[i].Name))
                    {
                        output.Append(userProperties[i].Name);
                        output.Append(": ");
                    }

                    int propertyOffset = output.Length;
                    RenderValue(userProperties[i], sbf);
                    TrySetSegment(i, propertyOffset, output, userSegments);
                }

                if (i + 1 < userProperties.Length)
                    output.Append(", ");
            }
        }

        private static void TrySetSegment(int segmentIndex, int propertyOffset, StringBuilder sb,
            Span<Segment> segments)
        {
            if ((uint)segmentIndex >= (uint)segments.Length)
                return;

            segments[segmentIndex] = new Segment(propertyOffset, sb.Length - propertyOffset);
        }

        private static int FindDateTime(ReadOnlySpan<NamedProperty> properties, string name, out DateTime value)
        {
            for (int i = 0; i != properties.Length; ++i)
            {
                NamedProperty p = properties[i];

                if (!string.Equals(p.Name, name, StringComparison.Ordinal))
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

                if (!string.Equals(p.Name, name, StringComparison.Ordinal))
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

        private static void RenderObject(object o, StringBuilderFacade sbf)
        {
            // TODO: Add analysing type for applying array formatting.
            sbf.Append(o);
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
    }
}
