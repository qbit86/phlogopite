using System;
using System.Text;

namespace Phlogopite
{
    public sealed class FormattingSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>
    {
        private readonly Level _minimumLevel;
        private readonly IFormatProvider _formatProvider;
        private readonly Formatter _formatter = Formatter.Default;

        public FormattingSink() : this(Level.Verbose, CultureConstants.FixedCulture) { }

        public FormattingSink(Level minimumLevel) : this(minimumLevel, CultureConstants.FixedCulture) { }

        public FormattingSink(Level minimumLevel, IFormatProvider formatProvider)
        {
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
                _formatter.Format(level, text, userProperties, writerProperties, mediatorProperties, _formatProvider,
                    sb, default, default, default);

#if DEBUG
                string test = sb.ToString();
                Console.WriteLine(test);
#endif
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
