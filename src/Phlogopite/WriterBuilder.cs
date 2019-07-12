using System;
using System.Runtime.CompilerServices;

namespace Phlogopite
{
    public readonly struct WriterBuilder : IEquatable<WriterBuilder>
    {
        private readonly IMediator<NamedProperty> _mediator;
        private readonly Level _minimumLevel;
        private readonly string _tag;

        public WriterBuilder(IMediator<NamedProperty> mediator, string tag) :
            this(mediator, Writer.DefaultMinimumLevel, tag) { }

        public WriterBuilder(Level minimumLevel, string tag) : this(Mediator.Silent, minimumLevel, tag) { }

        public WriterBuilder(IMediator<NamedProperty> mediator, Level minimumLevel, string tag)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _minimumLevel = minimumLevel;
            _tag = tag;
        }

        public Writer Build([CallerMemberName] string source = null)
        {
            return new Writer(_mediator, _minimumLevel, _tag, source);
        }

        public Writer Build(IMediator<NamedProperty> mediator, [CallerMemberName] string source = null)
        {
            return new Writer(mediator, _minimumLevel, _tag, source);
        }

        internal int GetAttachedPropertyCount(Level level)
        {
            if (_mediator is null)
                return Writer.WriterPropertyCount;

            return Writer.WriterPropertyCount + _mediator.GetAttachedPropertyCount(level);
        }

        public bool IsEnabled(Level level)
        {
            if (_mediator is null)
                return false;

            return _minimumLevel <= level && _mediator.IsEnabled(level);
        }

        internal void UncheckedWrite(Level level, string text, ReadOnlySpan<NamedProperty> userProperties,
            Span<NamedProperty> attachedProperties, string source)
        {
            if (_mediator is null || !_mediator.IsEnabled(level))
                return;

            int length = Math.Min(attachedProperties.Length, Writer.WriterPropertyCount);
            Span<NamedProperty> writerProperties = attachedProperties.Slice(0, length);
            if (writerProperties.Length > 0)
            {
                writerProperties[0] = new NamedProperty("tag", _tag);
                if (writerProperties.Length > 1)
                    writerProperties[1] = new NamedProperty("source", source);
            }

            _mediator.UncheckedWrite(level, text, userProperties, writerProperties, attachedProperties.Slice(length));
        }

        public bool Equals(WriterBuilder other)
        {
            if (_minimumLevel != other._minimumLevel)
                return false;

            if (!string.Equals(_tag, other._tag, StringComparison.Ordinal))
                return false;

            if (_mediator is null)
                return other._mediator is null;

            return _mediator.Equals(other._mediator);
        }

        public override bool Equals(object obj)
        {
            return obj is WriterBuilder other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked((int)_minimumLevel * 397) ^ (_mediator?.GetHashCode() ?? 0);
        }

        public static bool operator ==(WriterBuilder left, WriterBuilder right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WriterBuilder left, WriterBuilder right)
        {
            return !left.Equals(right);
        }
    }
}
