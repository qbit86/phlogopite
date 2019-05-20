using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Phlogopite.Sinks
{
    public sealed class FormattingSink : ISink<NamedProperty>
    {
        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly Level _minimumLevel;
        private readonly IReadOnlyList<IFormattedSink<NamedProperty>> _sinks;

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks) :
            this(sinks, Level.Verbose, Formatter.Default, CultureConstants.FixedCulture) { }

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks, IFormatter<NamedProperty> formatter) :
            this(sinks, Level.Verbose, formatter, CultureConstants.FixedCulture) { }

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks, Level minimumLevel) :
            this(sinks, minimumLevel, Formatter.Default, CultureConstants.FixedCulture) { }

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks, Level minimumLevel,
            IFormatter<NamedProperty> formatter) :
            this(sinks, minimumLevel, formatter, CultureConstants.FixedCulture) { }

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks, Level minimumLevel,
            IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _sinks = sinks ?? Array.Empty<IFormattedSink<NamedProperty>>();
            _minimumLevel = minimumLevel;
            _formatter = formatter ?? Formatter.Default;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
        }

        public bool IsEnabled(Level level)
        {
            if (_minimumLevel > level)
                return false;

            return _sinks.Count != 0;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            int capacity = FormattingHelpers.EstimateCapacity(text, userProperties, writerProperties);
            StringBuilder sb = StringBuilderCache.Acquire(capacity);
            try
            {
                Span<Range> userSegments = stackalloc Range[userProperties.Length];
                Span<Range> writerSegments = stackalloc Range[writerProperties.Length];
                Span<Range> mediatorSegments = stackalloc Range[mediatorProperties.Length];
                _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                    sb, userSegments, writerSegments, mediatorSegments);

                char[] buffer = ArrayPool<char>.Shared.Rent(sb.Length);
                try
                {
                    var formattedMessage = new ArraySegment<char>(buffer, 0, sb.Length);
                    sb.CopyTo(0, buffer, 0, sb.Length);
                    for (int i = 0; i < _sinks.Count; ++i)
                    {
                        IFormattedSink<NamedProperty> sink = _sinks[i];
                        sink.UncheckedWrite(level, text, userProperties, writerProperties, mediatorProperties,
                            formattedMessage, userSegments, writerSegments, mediatorSegments);
                    }
                }
                finally
                {
                    ArrayPool<char>.Shared.Return(buffer);
                }
            }
            finally
            {
                StringBuilderCache.Release(sb);
            }
        }
    }
}
