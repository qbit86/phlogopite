using System;
using System.Globalization;

namespace Phlogopite.Sinks
{
    public sealed class TraceSink : ISink<NamedProperty>, IFormattedSink<NamedProperty>
    {
        internal const Level DefaultMinimumLevel = Level.Verbose;

        internal static readonly CultureInfo DefaultFormatProvider = CultureConstants.FixedCulture;
        internal static readonly Formatter DefaultFormatter = Formatter.Default;

        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly Level _minimumLevel;

        public TraceSink() : this(DefaultMinimumLevel, DefaultFormatter, DefaultFormatProvider) { }

        public TraceSink(Level minimumLevel, IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _formatter = formatter ?? DefaultFormatter;
            _formatProvider = formatProvider ?? DefaultFormatProvider;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage,
            ReadOnlySpan<Range> userRanges, ReadOnlySpan<Range> writerRanges, ReadOnlySpan<Range> mediatorRanges)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            throw new NotImplementedException();
        }
    }
}
