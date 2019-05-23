using System;
using static System.Diagnostics.Debug;

namespace Phlogopite
{
    public readonly struct NamedProperty : IEquatable<NamedProperty>
    {
        private readonly string _name;
        private readonly PropertyValue _value;

        private NamedProperty(string name, PropertyValue value)
        {
#if DEBUG
            if (value.TypeCode == TypeCode.Object || value.TypeCode == TypeCode.String)
                Assert(value.ReferenceValue != null, "[NamedProperty.ctor] value.ReferenceValue != null");
#endif
            _name = name;
            _value = value;
        }

        public NamedProperty(string name, object value) :
            this(name, value is null ? default : new PropertyValue(value)) { }

        public NamedProperty(string name, string value) :
            this(name, value is null ? default : new PropertyValue(value)) { }

        public NamedProperty(string name, bool value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, byte value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, sbyte value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, char value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, short value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, ushort value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, int value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, uint value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, long value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, ulong value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, float value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, double value) : this(name, new PropertyValue(value)) { }
        public NamedProperty(string name, DateTime value) : this(name, new PropertyValue(value)) { }

        public string Name => _name;
        public TypeCode TypeCode => _value.TypeCode;

        // ReSharper disable InconsistentNaming

        public object AsObject => _value.ReferenceValue;
        public string AsString => _value.ReferenceValue as string;
        public bool AsBoolean => _value.ScalarValue.AsBoolean;
        public byte AsByte => _value.ScalarValue.AsByte;
        public sbyte AsSByte => _value.ScalarValue.AsSByte;
        public char AsChar => _value.ScalarValue.AsChar;
        public short AsInt16 => _value.ScalarValue.AsInt16;
        public ushort AsUInt16 => _value.ScalarValue.AsUInt16;
        public int AsInt32 => _value.ScalarValue.AsInt32;
        public uint AsUInt32 => _value.ScalarValue.AsUInt32;
        public long AsInt64 => _value.ScalarValue.AsInt64;
        public ulong AsUInt64 => _value.ScalarValue.AsUInt64;
        public float AsSingle => _value.ScalarValue.AsSingle;
        public double AsDouble => _value.ScalarValue.AsDouble;
        public DateTime AsDateTime => _value.ScalarValue.AsDateTime;

        // ReSharper restore InconsistentNaming

        public bool TryGetObject(out object value)
        {
            if (TypeCode != TypeCode.Object)
            {
                value = default;
                return false;
            }

            value = AsObject;
            Assert(value != null, "[NamedProperty.TryGetObject] value != null");
            return true;
        }

        public bool TryGetString(out string value)
        {
            if (TypeCode != TypeCode.String)
            {
                value = default;
                return false;
            }

            value = AsString;
            Assert(value != null, "[NamedProperty.TryGetString] value != null");
            return true;
        }

        public bool TryGetBoolean(out bool value)
        {
            if (TypeCode != TypeCode.Boolean)
            {
                value = default;
                return false;
            }

            value = AsBoolean;
            return true;
        }

        public bool TryGetByte(out byte value)
        {
            if (TypeCode != TypeCode.Byte)
            {
                value = default;
                return false;
            }

            value = AsByte;
            return true;
        }

        public bool TryGetSByte(out sbyte value)
        {
            if (TypeCode != TypeCode.SByte)
            {
                value = default;
                return false;
            }

            value = AsSByte;
            return true;
        }

        public bool TryGetChar(out char value)
        {
            if (TypeCode != TypeCode.Char)
            {
                value = default;
                return false;
            }

            value = AsChar;
            return true;
        }

        public bool TryGetInt16(out short value)
        {
            if (TypeCode != TypeCode.Int16)
            {
                value = default;
                return false;
            }

            value = AsInt16;
            return true;
        }

        public bool TryGetUInt16(out ushort value)
        {
            if (TypeCode != TypeCode.UInt16)
            {
                value = default;
                return false;
            }

            value = AsUInt16;
            return true;
        }

        public bool TryGetInt32(out int value)
        {
            if (TypeCode != TypeCode.Int32)
            {
                value = default;
                return false;
            }

            value = AsInt32;
            return true;
        }

        public bool TryGetUInt32(out uint value)
        {
            if (TypeCode != TypeCode.UInt32)
            {
                value = default;
                return false;
            }

            value = AsUInt32;
            return true;
        }

        public bool TryGetInt64(out long value)
        {
            if (TypeCode != TypeCode.Int64)
            {
                value = default;
                return false;
            }

            value = AsInt64;
            return true;
        }

        public bool TryGetUInt64(out ulong value)
        {
            if (TypeCode != TypeCode.UInt64)
            {
                value = default;
                return false;
            }

            value = AsUInt64;
            return true;
        }

        public bool TryGetSingle(out float value)
        {
            if (TypeCode != TypeCode.Single)
            {
                value = default;
                return false;
            }

            value = AsSingle;
            return true;
        }

        public bool TryGetDouble(out double value)
        {
            if (TypeCode != TypeCode.Double)
            {
                value = default;
                return false;
            }

            value = AsDouble;
            return true;
        }

        public bool TryGetDateTime(out DateTime value)
        {
            if (TypeCode != TypeCode.DateTime)
            {
                value = default;
                return false;
            }

            value = AsDateTime;
            return true;
        }

        public bool Equals(NamedProperty other)
        {
            if (!_value.Equals(other._value))
                return false;

            return string.Equals(_name, other._name, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            return obj is NamedProperty other && Equals(other);
        }

        public override int GetHashCode()
        {
            int nameHashCode = _name is null ? 0 : StringComparer.Ordinal.GetHashCode(_name);
            return HashHelpers.Combine(_value.GetHashCode(), nameHashCode);
        }

        public static bool operator ==(NamedProperty left, NamedProperty right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NamedProperty left, NamedProperty right)
        {
            return !left.Equals(right);
        }

#pragma warning disable CA2225 // Operator overloads have named alternates
        public static implicit operator NamedProperty((string name, object value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, string value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, bool value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, byte value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, sbyte value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, char value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, short value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, ushort value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, int value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, uint value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, long value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, ulong value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, float value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, double value) t)
        {
            return new NamedProperty(t.name, t.value);
        }

        public static implicit operator NamedProperty((string name, DateTime value) t)
        {
            return new NamedProperty(t.name, t.value);
        }
#pragma warning restore CA2225 // Operator overloads have named alternates
    }
}
