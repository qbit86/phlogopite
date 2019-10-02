using System;

// ReSharper disable once CheckNamespace

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Phlogopite
{
    public readonly struct Range : IEquatable<Range>
    {
        public Range(int start, int end)
        {
            if (start < 0)
                ThrowNeedNonNegNumException(nameof(start));

            if (end < start)
                ThrowArgumentOutOfRangeException(nameof(start));

            Start = start;
            End = end;
        }

        public int Start { get; }

        public int End { get; }

        public int Length => End - Start;

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

        private static void ThrowNeedNonNegNumException(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName, "Non-negative number required.");
        }

        private static void ThrowArgumentOutOfRangeException(string paramName)
        {
            throw new ArgumentOutOfRangeException(paramName);
        }
    }
}
