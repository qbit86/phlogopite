using System;

namespace Phlogopite
{
    public sealed class ConsoleLoggerBuilder
    {
        private bool? _emitLevel;
        private bool? _emitTime;
        private IFormatProvider _formatProvider;
        private IFormatter<NamedProperty> _formatter;
        private bool? _isSynchronized;
        private Level? _minimumLevel;

        public IFormatProvider FormatProvider
        {
            get => _formatProvider ?? ConsoleLogger.DefaultFormatProvider;
            set => _formatProvider = value;
        }

        public IFormatter<NamedProperty> Formatter
        {
            get => _formatter ?? ConsoleLogger.DefaultFormatter;
            set => _formatter = value;
        }

        public bool IsSynchronized
        {
            get => _isSynchronized.GetValueOrDefault(ConsoleLogger.DefaultIsSynchronized);
            set => _isSynchronized = value;
        }

        public Level MinimumLevel
        {
            get => _minimumLevel.GetValueOrDefault(ConsoleLogger.DefaultMinimumLevel);
            set => _minimumLevel = value;
        }

        public bool EmitLevel
        {
            get => _emitLevel.GetValueOrDefault(ConsoleLogger.DefaultEmitLevel);
            set => _emitLevel = value;
        }

        public bool EmitTime
        {
            get => _emitTime.GetValueOrDefault(ConsoleLogger.DefaultEmitTime);
            set => _emitTime = value;
        }

        public Level? StandardErrorMinimumLevel { get; set; }

        public ConsoleLogger Build()
        {
            return new ConsoleLogger(MinimumLevel, StandardErrorMinimumLevel, IsSynchronized, EmitLevel, EmitTime,
                Formatter, FormatProvider);
        }
    }
}
