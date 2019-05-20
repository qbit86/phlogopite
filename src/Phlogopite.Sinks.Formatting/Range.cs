using System;

// ReSharper disable once CheckNamespace

namespace Phlogopite
{
    public readonly struct Range : IEquatable<Range>
    {
        public Range(int start, int end)
        {
            if (start < 0)
                ThrowRangeCtorValidationFailedException(nameof(start));

            if (end < start)
                ThrowRangeCtorValidationFailedException(nameof(end));

            Start = start;
            End = end;
        }

        public int Start { get; }

        public int End { get; }

        public bool IsEmpty => Start == End;

        public bool Equals(Range other)
        {
            return Start == other.Start && End == other.End;
        }

        public override bool Equals(object obj)
        {
            return obj is Range other && Equals(other);
        }

        public override int GetHashCode()
        {
            return unchecked(Start * 397) ^ End;
        }

        public static bool operator ==(Range left, Range right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Range left, Range right)
        {
            return !left.Equals(right);
        }

        private static void ThrowRangeCtorValidationFailedException(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, "Non-negative number required.");
        }
    }
}
