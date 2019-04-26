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

        private PropertyValue(bool value) : this(new Scalar { AsBoolean = value }, TypeCode.Boolean) { }
        private PropertyValue(byte value) : this(new Scalar { AsByte = value }, TypeCode.Byte) { }
        private PropertyValue(sbyte value) : this(new Scalar { AsSByte = value }, TypeCode.SByte) { }
        private PropertyValue(char value) : this(new Scalar { AsChar = value }, TypeCode.Char) { }
        private PropertyValue(short value) : this(new Scalar { AsInt16 = value }, TypeCode.Int16) { }
        private PropertyValue(ushort value) : this(new Scalar { AsUInt16 = value }, TypeCode.UInt16) { }
        private PropertyValue(int value) : this(new Scalar { AsInt32 = value }, TypeCode.Int32) { }
        private PropertyValue(uint value) : this(new Scalar { AsUInt32 = value }, TypeCode.UInt32) { }
        private PropertyValue(long value) : this(new Scalar { AsInt64 = value }, TypeCode.Int64) { }
        private PropertyValue(ulong value) : this(new Scalar { AsUInt64 = value }, TypeCode.UInt64) { }
        private PropertyValue(float value) : this(new Scalar { AsSingle = value }, TypeCode.Single) { }
        private PropertyValue(double value) : this(new Scalar { AsDouble = value }, TypeCode.Double) { }
        private PropertyValue(DateTime value) : this(new Scalar { AsDateTime = value }, TypeCode.DateTime) { }

        internal object ReferenceValue => _reference;

        internal Scalar ScalarValue => _scalar;

        internal TypeCode TypeCode => _typeCode;
    }
}
