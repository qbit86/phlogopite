using System;
using System.Diagnostics;

namespace Phlogopite
{
    public static class SpanBuilder
    {
        public static SpanBuilder<T> Create<T>(T[] array)
        {
            return new SpanBuilder<T>(array);
        }

        public static SpanBuilder<T> Create<T>(T[] array, int offset, int count)
        {
            return new SpanBuilder<T>(array, offset, count);
        }
    }

#pragma warning disable CA1066 // Type {0} should implement IEquatable<T> because it overrides Equals

    public readonly ref struct SpanBuilder<T>
    {
        private readonly T[] _array;
        private readonly int _offset;
        private readonly int _count;

        public SpanBuilder(T[] array)
        {
            if (array is null)
                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);

            Debug.Assert(array != null, "array != null");

            _array = array;
            _offset = 0;
#pragma warning disable CA1062 // Validate arguments of public methods
            _count = array.Length;
#pragma warning restore CA1062 // Validate arguments of public methods
        }

        public SpanBuilder(T[] array, int offset, int count)
        {
            if (array is null || (uint)offset > (uint)array.Length || (uint)count > (uint)(array.Length - offset))
                ThrowHelper.ThrowArraySegmentCtorValidationFailedExceptions(array, offset, count);

            _array = array;
            _offset = offset;
            _count = count;
        }

        public int Capacity => _array.Length - _offset;

        public int Count => _count;

        internal T[] Array => _array;

        internal int Offset => _offset;

#pragma warning disable CA2225 // Operator overloads have named alternates

        public static implicit operator ReadOnlySpan<T>(SpanBuilder<T> segment)
        {
            return new Span<T>(segment._array, segment._offset, segment._count);
        }

#pragma warning restore CA2225 // Operator overloads have named alternates

        // ReSharper disable InconsistentNaming

        public ReadOnlySpan<T> AsSpan()
        {
            return new ReadOnlySpan<T>(_array, _offset, _count);
        }

        public ReadOnlySpan<T> AsSpan(int start)
        {
            if ((uint)start > (uint)_count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);

            return new ReadOnlySpan<T>(_array, _offset + start, _count - start);
        }

        public ReadOnlySpan<T> AsSpan(int start, int length)
        {
            if ((uint)start > (uint)_count)
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.start);

            if ((uint)length > (uint)(_count - start))
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.length);

            return new ReadOnlySpan<T>(_array, _offset + start, length);
        }

        // ReSharper restore InconsistentNaming

        public bool TryAppend(T item, out SpanBuilder<T> result)
        {
            if (_offset + _count >= _array.Length)
            {
                result = default;
                return false;
            }

            _array[_offset + _count] = item;
            result = new SpanBuilder<T>(_array, _offset, _count + 1);
            return true;
        }

        public bool Equals(SpanBuilder<T> other)
        {
            return _array.Equals(other._array) && _offset == other._offset && _count == other._count;
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _array.GetHashCode();
                hashCode = (hashCode * 397) ^ _offset;
                hashCode = (hashCode * 397) ^ _count;
                return hashCode;
            }
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
