using System;
using System.Text;

namespace Phlogopite
{
    public sealed class FormattingSink : ISink<NamedProperty>, IMediator<NamedProperty>, IWriter<NamedProperty>
    {
        private readonly Level _minimumLevel;
        private readonly IFormatProvider _formatProvider;

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
                throw new NotImplementedException();
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