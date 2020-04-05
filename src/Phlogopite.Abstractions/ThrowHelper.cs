using System;
using System.Diagnostics;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Phlogopite
{
    internal static class ThrowHelper
    {
        internal static void ThrowArgumentNullException(ExceptionArgument argument)
        {
            throw GetArgumentNullException(argument);
        }

        internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
        {
            throw new ArgumentOutOfRangeException(GetArgumentName(argument));
        }

        private static string GetArgumentName(ExceptionArgument argument)
        {
            switch (argument)
            {
                case ExceptionArgument.array:
                    return nameof(ExceptionArgument.array);
                case ExceptionArgument.initialCount:
                    return nameof(ExceptionArgument.initialCount);
                case ExceptionArgument.length:
                    return nameof(ExceptionArgument.length);
                case ExceptionArgument.start:
                    return nameof(ExceptionArgument.start);
                default:
                    Debug.Fail("The enum value is not defined, please check the ExceptionArgument Enum.");
                    return string.Empty;
            }
        }

        private static ArgumentNullException GetArgumentNullException(ExceptionArgument argument)
        {
            return new ArgumentNullException(GetArgumentName(argument));
        }
    }

    // ReSharper disable InconsistentNaming

    internal enum ExceptionArgument
    {
        array,
        initialCount,
        length,
        start
    }

    // ReSharper restore InconsistentNaming
}
