using System;

namespace Phlogopite
{
    // https://github.com/dotnet/corefx/blob/master/src/Common/src/CoreLib/System/Diagnostics/Tracing/TraceLogging/PropertyValue.cs

    internal readonly struct PropertyValue
    {
        private readonly object _reference;
        private readonly Scalar _scalar;
        private readonly TypeCode _typeCode;

        internal PropertyValue(object value)
        {
            _reference = value;
            _scalar = default;
            _typeCode = TypeCode.Object;
        }

        internal PropertyValue(Scalar scalar, TypeCode typeCode)
        {
            _reference = null;
            _scalar = scalar;
            _typeCode = typeCode;
        }
    }
}
