using System;

namespace Phlogopite
{
    public static class SpanBuilder
    {
        public static SpanBuilder<T> Create<T>(Span<T> span)
        {
            return new SpanBuilder<T>(span);
        }

        public static SpanBuilder<T> Create<T>(Span<T> span, int offset, int count)
        {
            return new SpanBuilder<T>(span, offset, count);
        }
    }

#pragma warning disable CA1066 // Type {0} should implement IEquatable<T> because it overrides Equals

    public readonly ref struct SpanBuilder<T>
    {
        private readonly Span<T> _span;
        private readonly int _count;

        public SpanBuilder(Span<T> span)
        {
            _span = span;
            _count = span.Length;
        }

        public SpanBuilder(Span<T> span, int offset, int count)
        {
            if ((uint)offset > (uint)span.Length || (uint)count > (uint)(span.Length - offset))
                ThrowHelper.ThrowArraySegmentCtorValidationFailedExceptions(span.Length, offset, count);

            _span = span.Slice(offset);
            _count = count;
        }

        public int Capacity => _span.Length;

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
            return new SpanBuilder<T>(segment.Array, segment.Offset, segment.Count);
        }

        public static implicit operator ReadOnlySpan<T>(SpanBuilder<T> spanBuilder)
        {
            return spanBuilder._span.Slice(0, spanBuilder._count);
        }

#pragma warning restore CA2225 // Operator overloads have named alternates

        public ref readonly T this[int index] => ref _span[index];

        // ReSharper disable InconsistentNaming

        public ReadOnlySpan<T> AsSpan()
        {
            return _span.Slice(0, _count);
        }

        public ReadOnlySpan<T> AsSpan(int start)
        {
            if ((uint)start > (uint)_count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);

            return _span.Slice(start, _count - start);
        }

        public ReadOnlySpan<T> AsSpan(int start, int length)
        {
            if ((uint)start > (uint)_count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);

            if ((uint)length > (uint)(_count - start))
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);

            return _span.Slice(start, length);
        }

        // ReSharper restore InconsistentNaming

        public bool TryAppend(T item, out SpanBuilder<T> result)
        {
            if (_count >= _span.Length)
            {
                result = this;
                return false;
            }

            _span[_count] = item;
            result = new SpanBuilder<T>(_span, 0, _count + 1);
            return true;
        }

        public override string ToString()
        {
            return AsSpan().ToString();
        }

        public bool Equals(SpanBuilder<T> other)
        {
            return _span == other._span && _count == other._count;
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
