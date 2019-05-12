using System;

// ReSharper disable once CheckNamespace
namespace Phlogopite
{
    public readonly struct Segment : IEquatable<Segment>
    {
        public Segment(int offset, int count)
        {
            if (offset < 0)
                ThrowSegmentCtorValidationFailedException(nameof(offset));

            if (count < 0)
                ThrowSegmentCtorValidationFailedException(nameof(count));

            Offset = offset;
            Count = count;
        }

        public int Offset { get; }

        public int Count { get; }

        public bool IsEmpty => Count == 0;

        public bool Equals(Segment other)
        {
            return Offset == other.Offset && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            return obj is Segment other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked(Offset * 397) ^ Count;
        }

        public static bool operator ==(Segment left, Segment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Segment left, Segment right)
        {
            return !left.Equals(right);
        }

        private static void ThrowSegmentCtorValidationFailedException(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, "Non-negative number required.");
        }
    }
}
