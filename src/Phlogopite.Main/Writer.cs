using System;
using System.Buffers;

namespace Phlogopite
{
    public readonly struct Writer : IWriter<NamedProperty>, IEquatable<Writer>
    {
        private readonly IMediator<NamedProperty> _mediator;
        private readonly string _tag;
        private readonly Level _minimumLevel;

        public Writer(IMediator<NamedProperty> mediator, string tag) : this(mediator, tag, Level.Verbose) { }

        public Writer(IMediator<NamedProperty> mediator, string tag, Level minimumLevel)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _tag = tag;
            _minimumLevel = minimumLevel;
        }

        public bool IsEnabled(Level level)
        {
            return _minimumLevel <= level;
        }

        public void Write(Level level, string text, ReadOnlySpan<NamedProperty> properties)
        {
            if (_mediator is null)
                return;

            NamedProperty[] writerProperties = ArrayPool<NamedProperty>.Shared.Rent(1);
            try
            {
                writerProperties[0] = new NamedProperty("tag", _tag);
                _mediator.Write(level, text, properties, writerProperties.AsSpan(0, 1));
            }
            finally
            {
                ArrayPool<NamedProperty>.Shared.Return(writerProperties, true);
            }
        }

        public bool Equals(Writer other)
        {
            if (_minimumLevel != other._minimumLevel)
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

        public static bool operator ==(Writer left, Writer right) => left.Equals(right);

        public static bool operator !=(Writer left, Writer right) => !left.Equals(right);
    }
}
