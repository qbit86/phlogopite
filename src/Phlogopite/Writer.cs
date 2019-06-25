using System;
using System.Runtime.CompilerServices;

namespace Phlogopite
{
    public readonly struct Writer : IWriter<NamedProperty>, IEquatable<Writer>
    {
        internal const Level DefaultMinimumLevel = Level.Verbose;
        private const int WriterPropertyCount = 2;

        private readonly IMediator<NamedProperty> _mediator;
        private readonly Level _minimumLevel;
        private readonly string _tag;
        private readonly string _source;

        public Writer(IMediator<NamedProperty> mediator, string tag, [CallerMemberName] string source = null) :
            this(mediator, DefaultMinimumLevel, tag, source) { }

        public Writer(IMediator<NamedProperty> mediator, Level minimumLevel, string tag,
            [CallerMemberName] string source = null)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _minimumLevel = minimumLevel;
            _tag = tag;
            _source = source;
        }

        public int GetAttachedPropertyCount(Level level)
        {
            if (_mediator is null)
                return WriterPropertyCount;

            return WriterPropertyCount + _mediator.GetAttachedPropertyCount(level);
        }

        public bool IsEnabled(Level level)
        {
            if (_mediator is null)
                return false;

            return _minimumLevel <= level && _mediator.IsEnabled(level);
        }

        public void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            Span<NamedProperty> attachedProperties)
        {
            if (_mediator is null || !_mediator.IsEnabled(level))
                return;

            int length = Math.Min(attachedProperties.Length, WriterPropertyCount);
            Span<NamedProperty> writerProperties = attachedProperties.Slice(0, length);
            if (writerProperties.Length > 0)
            {
                writerProperties[0] = new NamedProperty("tag", _tag);
                if (writerProperties.Length > 1)
                    writerProperties[1] = new NamedProperty("source", _source);
            }

            _mediator.UncheckedWrite(level, text, userProperties, writerProperties, attachedProperties.Slice(length));
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            if (!IsEnabled(level))
                return;

            UncheckedWrite(level, text, properties, default);
        }

        public bool Equals(Writer other)
        {
            if (_minimumLevel != other._minimumLevel)
                return false;

            if (!string.Equals(_tag, other._tag, StringComparison.Ordinal))
                return false;

            if (!string.Equals(_source, other._source, StringComparison.Ordinal))
                return false;

            if (_mediator is null)
                return other._mediator is null;

            return _mediator.Equals(other._mediator);
        }

        public override bool Equals(object obj)
        {
            return obj is Writer other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked((int)_minimumLevel * 397) ^ (_mediator?.GetHashCode() ?? 0);
        }

        public static bool operator ==(Writer left, Writer right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Writer left, Writer right)
        {
            return !left.Equals(right);
        }
    }
}
