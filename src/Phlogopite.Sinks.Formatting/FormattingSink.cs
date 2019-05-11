using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Phlogopite.Sinks
{
    public sealed class FormattingSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>
    {
        private readonly IReadOnlyList<IFormattedSink<NamedProperty>> _sinks;
        private readonly Level _minimumLevel;
        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter = Formatter.Default;

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks)
            : this(sinks, Level.Verbose, CultureConstants.FixedCulture) { }

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks, Level minimumLevel)
            : this(sinks, minimumLevel, CultureConstants.FixedCulture) { }

        public FormattingSink(IReadOnlyList<IFormattedSink<NamedProperty>> sinks, Level minimumLevel,
            IFormatProvider formatProvider)
        {
            _sinks = sinks ?? Array.Empty<IFormattedSink<NamedProperty>>();
            _minimumLevel = minimumLevel;
            _formatProvider = formatProvider ?? CultureConstants.FixedCulture;
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            if (!IsEnabled(level))
                return;

            StringBuilder sb = StringBuilderCache.Acquire();
            try
            {
                Span<Segment> userSegments = stackalloc Segment[userProperties.Length];
                Span<Segment> writerSegments = stackalloc Segment[writerProperties.Length];
                Span<Segment> mediatorSegments = stackalloc Segment[mediatorProperties.Length];
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
                        sink.Write(level, text, userProperties, writerProperties, mediatorProperties,
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

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties)
        {
            Write(level, text, userProperties, writerProperties, default);
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            Write(level, text, properties, default, default);
        }
    }
}
