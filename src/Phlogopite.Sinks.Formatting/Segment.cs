using System;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public readonly struct Segment : IEquatable<Segment>
    {
        public Segment(int start, int count)
        {
            if (start < 0)
                ThrowSegmentCtorValidationFailedException(nameof(start));

            if (count < 0)
                ThrowSegmentCtorValidationFailedException(nameof(count));

            Start = start;
            Count = count;
        }

        public int Start { get; }

        public int Count { get; }

        public int End => Start + Count;

        public bool IsEmpty => Count == 0;

        public bool Equals(Segment other)
        {
            return Start == other.Start && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            return obj is Segment other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked(Start * 397) ^ Count;
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
