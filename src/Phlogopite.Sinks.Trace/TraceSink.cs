using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Phlogopite.Sinks
{
    public sealed class TraceSink : ISink<NamedProperty>, IFormattedSink<NamedProperty>
    {
        private const Level DefaultMinimumLevel = Level.Verbose;

        internal static readonly CultureInfo DefaultFormatProvider = CultureConstants.FixedCulture;
        internal static readonly Formatter DefaultFormatter = Formatter.Default;

        private readonly IFormatProvider _formatProvider;
        private readonly IFormatter<NamedProperty> _formatter;
        private readonly Level _minimumLevel;

        public TraceSink() : this(DefaultMinimumLevel, DefaultFormatter, DefaultFormatProvider) { }

        public TraceSink(Level minimumLevel) : this(minimumLevel, DefaultFormatter, DefaultFormatProvider) { }

        public TraceSink(Level minimumLevel, IFormatProvider formatProvider) :
            this(minimumLevel, DefaultFormatter, formatProvider) { }

        public TraceSink(Level minimumLevel, IFormatter<NamedProperty> formatter, IFormatProvider formatProvider)
        {
            _minimumLevel = minimumLevel;
            _formatter = formatter ?? DefaultFormatter;
            _formatProvider = formatProvider ?? DefaultFormatProvider;
        }

        public static TraceSink Default { get; } = new TraceSink();

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties,
            ArraySegment<char> formattedMessage,
            ReadOnlySpan<Range> userRanges, ReadOnlySpan<Range> writerRanges, ReadOnlySpan<Range> mediatorRanges)
        {
            const int levelLength = 2;
            if (formattedMessage.Count <= levelLength)
                return;

            string trimmedText = new string(formattedMessage.Array,
                formattedMessage.Offset + levelLength, formattedMessage.Count - levelLength);
            WriteLine(level, trimmedText);
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> writerProperties, ReadOnlySpan<NamedProperty> mediatorProperties)
        {
            int capacity = FormattingHelpers.EstimateCapacity(text, userProperties, writerProperties);
            StringBuilder sb = StringBuilderCache.Acquire(capacity);
            try
            {
                _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                    sb, default, default, default);

                const int levelLength = 2;
                if (sb.Length <= levelLength)
                    return;

                WriteLine(level, sb.ToString(levelLength, sb.Length - levelLength));
            }
            finally
            {
                StringBuilderCache.Release(sb);
            }
        }

        private static void WriteLine(Level level, string text)
        {
            switch (level)
            {
                case Level.Error:
                case Level.Assert:
                    Trace.TraceError(text);
                    return;
                case Level.Warning:
                    Trace.TraceWarning(text);
                    return;
                case Level.Info:
                    Trace.TraceInformation(text);
                    return;
                default:
                    Trace.WriteLine(text);
                    return;
            }
        }
    }
}
