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

        internal PropertyValue(string value)
        {
            _reference = value;
            _scalar = default;
            _typeCode = TypeCode.String;
        }

        internal PropertyValue(bool value) : this(new Scalar { AsBoolean = value }, TypeCode.Boolean) { }
        internal PropertyValue(byte value) : this(new Scalar { AsByte = value }, TypeCode.Byte) { }
        internal PropertyValue(sbyte value) : this(new Scalar { AsSByte = value }, TypeCode.SByte) { }
        internal PropertyValue(char value) : this(new Scalar { AsChar = value }, TypeCode.Char) { }
        internal PropertyValue(short value) : this(new Scalar { AsInt16 = value }, TypeCode.Int16) { }
        internal PropertyValue(ushort value) : this(new Scalar { AsUInt16 = value }, TypeCode.UInt16) { }
        internal PropertyValue(int value) : this(new Scalar { AsInt32 = value }, TypeCode.Int32) { }
        internal PropertyValue(uint value) : this(new Scalar { AsUInt32 = value }, TypeCode.UInt32) { }
        internal PropertyValue(long value) : this(new Scalar { AsInt64 = value }, TypeCode.Int64) { }
        internal PropertyValue(ulong value) : this(new Scalar { AsUInt64 = value }, TypeCode.UInt64) { }
        internal PropertyValue(float value) : this(new Scalar { AsSingle = value }, TypeCode.Single) { }
        internal PropertyValue(double value) : this(new Scalar { AsDouble = value }, TypeCode.Double) { }
        internal PropertyValue(DateTime value) : this(new Scalar { AsDateTime = value }, TypeCode.DateTime) { }

        internal object ReferenceValue => _reference;

        internal Scalar ScalarValue => _scalar;

        internal TypeCode TypeCode => _typeCode;

        public override int GetHashCode()
        {
            int hash = 5381;
            hash = HashHelpers.Combine(hash, (int)_typeCode);
            hash = HashHelpers.Combine(hash, _scalar.AsInt32);
            if (_reference != null)
                hash = HashHelpers.Combine(hash, _reference.GetHashCode());

            return hash;
        }

        internal bool Equals(PropertyValue other)
        {
            if (_typeCode != other._typeCode || _scalar.AsInt64 != other._scalar.AsInt64)
                return false;

            if (_reference is null)
                return other._reference is null;

            return _reference.Equals(other._reference);
        }
    }
}
