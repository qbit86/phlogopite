using System;
using System.Runtime.CompilerServices;

namespace Phlogopite
{
    public readonly struct WriterBuilder : IEquatable<WriterBuilder>
    {
        private readonly IMediator<NamedProperty> _mediator;
        private readonly Level? _minimumLevel;
        private readonly string _tag;

        public WriterBuilder(IMediator<NamedProperty> mediator, string tag)
        {
            _mediator = mediator;
            _minimumLevel = null;
            _tag = tag;
        }

        public WriterBuilder(Level minimumLevel, string tag) : this(null, minimumLevel, tag) { }

        public WriterBuilder(IMediator<NamedProperty> mediator, Level minimumLevel, string tag)
        {
            _mediator = mediator;
            _minimumLevel = minimumLevel;
            _tag = tag;
        }

        public Writer Build([CallerMemberName] string source = null)
        {
            return new Writer(_mediator, _minimumLevel.GetValueOrDefault(Writer.DefaultMinimumLevel), _tag, source);
        }

        public Writer Build(IMediator<NamedProperty> mediator, [CallerMemberName] string source = null)
        {
            return new Writer(mediator, _minimumLevel.GetValueOrDefault(Writer.DefaultMinimumLevel), _tag, source);
        }

        public bool Equals(WriterBuilder other)
        {
            return Equals(_mediator, other._mediator) && _minimumLevel == other._minimumLevel &&
                string.Equals(_tag, other._tag, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return obj is WriterBuilder other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked((int)_minimumLevel.GetValueOrDefault() * 397) ^ (_mediator?.GetHashCode() ?? 0);
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
