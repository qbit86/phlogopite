using System;

namespace Phlogopite.Sinks
{
    public sealed class ConsoleSinkBuilder
    {
        private bool? _emitLevel;
        private bool? _emitTime;
        private IFormatProvider _formatProvider;
        private IFormatter<NamedProperty> _formatter;
        private bool? _isSynchronized;
        private Level? _minimumLevel;

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

        public bool EmitLevel
        {
            get => _emitLevel.GetValueOrDefault(ConsoleSink.DefaultEmitLevel);
            set => _emitLevel = value;
        }

        public bool EmitTime
        {
            get => _emitTime.GetValueOrDefault(ConsoleSink.DefaultEmitTime);
            set => _emitTime = value;
        }

        public Level? StandardErrorMinimumLevel { get; set; }

        public ConsoleSink Build()
        {
            return new ConsoleSink(MinimumLevel, StandardErrorMinimumLevel, IsSynchronized, EmitLevel, EmitTime,
                Formatter, FormatProvider);
        }
    }
}
