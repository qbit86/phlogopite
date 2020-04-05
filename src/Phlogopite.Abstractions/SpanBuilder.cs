using System;

namespace Phlogopite
{
    public static class SpanBuilder
    {
        public static SpanBuilder<T> Create<T>(Span<T> availableSpan)
        {
            return new SpanBuilder<T>(availableSpan);
        }

        public static SpanBuilder<T> Create<T>(Span<T> availableSpan, int initialCount)
        {
            return new SpanBuilder<T>(availableSpan, initialCount);
        }
    }

#pragma warning disable CA1066 // Type {0} should implement IEquatable<T> because it overrides Equals

    public readonly ref struct SpanBuilder<T>
    {
        private readonly Span<T> _availableSpan;
        private readonly int _count;

        public SpanBuilder(Span<T> availableSpan)
        {
            _availableSpan = availableSpan;
            _count = 0;
        }

        public SpanBuilder(Span<T> availableSpan, int initialCount)
        {
            if ((uint)initialCount > (uint)availableSpan.Length)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.initialCount);

            _availableSpan = availableSpan;
            _count = initialCount;
        }

        public int Capacity => _availableSpan.Length;

        public int Count => _count;

        public bool IsEmpty => _count == 0;

#pragma warning disable CA2225 // Operator overloads have named alternates

        public static implicit operator SpanBuilder<T>(Span<T> span)
        {
            return new SpanBuilder<T>(span);
        }

        public static implicit operator SpanBuilder<T>(T[] array)
        {
            return new SpanBuilder<T>(array);
        }

        public static implicit operator SpanBuilder<T>(ArraySegment<T> segment)
        {
            return new SpanBuilder<T>(segment.AsSpan());
        }

        public static implicit operator ReadOnlySpan<T>(SpanBuilder<T> spanBuilder)
        {
            return spanBuilder._availableSpan.Slice(0, spanBuilder._count);
        }

#pragma warning restore CA2225 // Operator overloads have named alternates

        public ref readonly T this[int index] => ref _availableSpan[index];

        // ReSharper disable InconsistentNaming

        public ReadOnlySpan<T> AsSpan()
        {
            return _availableSpan.Slice(0, _count);
        }

        public ReadOnlySpan<T> AsSpan(int start)
        {
            if ((uint)start > (uint)_count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);

            return _availableSpan.Slice(start, _count - start);
        }

        public ReadOnlySpan<T> AsSpan(int start, int length)
        {
            if ((uint)start > (uint)_count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);

            if ((uint)length > (uint)(_count - start))
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);

            return _availableSpan.Slice(start, length);
        }

        // ReSharper restore InconsistentNaming

        public bool TryAppend(T item, out SpanBuilder<T> result)
        {
            if (_count >= _availableSpan.Length)
            {
                result = this;
                return false;
            }

            _availableSpan[_count] = item;
            result = new SpanBuilder<T>(_availableSpan, _count + 1);
            return true;
        }

        public override string ToString()
        {
            return AsSpan().ToString();
        }

        public bool Equals(SpanBuilder<T> other)
        {
            return _availableSpan == other._availableSpan && _count == other._count;
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return _count.GetHashCode();
        }

        public static bool operator ==(SpanBuilder<T> left, SpanBuilder<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SpanBuilder<T> left, SpanBuilder<T> right)
        {
            return !left.Equals(right);
        }
    }

#pragma warning restore CA1066 // Type {0} should implement IEquatable<T> because it overrides Equals
}
