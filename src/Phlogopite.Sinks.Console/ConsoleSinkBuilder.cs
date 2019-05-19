using System;

namespace Phlogopite.Sinks
{
    public sealed class ConsoleSinkBuilder
    {
        private IFormatProvider _formatProvider;
        private IFormatter<NamedProperty> _formatter;
        private bool? _isSynchronized;
        private Level? _minimumLevel;
        private bool? _omitLevel;
        private bool? _omitTime;

        public IFormatProvider FormatProvider
        {
            get => _formatProvider ?? CultureConstants.FixedCulture;
            set => _formatProvider = value;
        }

        public IFormatter<NamedProperty> Formatter
        {
            get => _formatter ?? Phlogopite.Formatter.Default;
            set => _formatter = value;
        }

        public bool IsSynchronized
        {
            get => _isSynchronized.GetValueOrDefault();
            set => _isSynchronized = value;
        }

        public Level MinimumLevel
        {
            get => _minimumLevel ?? Level.Verbose;
            set => _minimumLevel = value;
        }

        public bool OmitLevel
        {
            get => _omitLevel.GetValueOrDefault();
            set => _omitLevel = value;
        }

        public bool OmitTime
        {
            get => _omitTime.GetValueOrDefault();
            set => _omitTime = value;
        }

        public Level? StandardErrorMinimumLevel { get; set; }

        public ConsoleSink Build()
        {
            return new ConsoleSink(MinimumLevel, StandardErrorMinimumLevel, IsSynchronized, OmitLevel, OmitTime,
                Formatter, FormatProvider);
        }
    }
}
