using System;
using static System.Diagnostics.Debug;

namespace Phlogopite
{
    public readonly struct Property
    {
        private readonly string _name;
        private readonly PropertyValue _value;

        private Property(string name, PropertyValue value)
        {
#if DEBUG
            if (value.TypeCode == TypeCode.Object || value.TypeCode == TypeCode.String)
                Assert(value.ReferenceValue != null, "[Property.ctor] value.ReferenceValue != null");
#endif
            _name = name;
            _value = value;
        }

        public Property(string name, object value) : this(name, value is null ? default : new PropertyValue(value)) { }
        public Property(string name, string value) : this(name, value is null ? default : new PropertyValue(value)) { }
        public Property(string name, bool value) : this(name, new PropertyValue(value)) { }
        public Property(string name, byte value) : this(name, new PropertyValue(value)) { }
        public Property(string name, sbyte value) : this(name, new PropertyValue(value)) { }
        public Property(string name, char value) : this(name, new PropertyValue(value)) { }
        public Property(string name, short value) : this(name, new PropertyValue(value)) { }
        public Property(string name, ushort value) : this(name, new PropertyValue(value)) { }
        public Property(string name, int value) : this(name, new PropertyValue(value)) { }
        public Property(string name, uint value) : this(name, new PropertyValue(value)) { }
        public Property(string name, long value) : this(name, new PropertyValue(value)) { }
        public Property(string name, ulong value) : this(name, new PropertyValue(value)) { }
        public Property(string name, float value) : this(name, new PropertyValue(value)) { }
        public Property(string name, double value) : this(name, new PropertyValue(value)) { }
        public Property(string name, DateTime value) : this(name, new PropertyValue(value)) { }

        public string Name => _name;

        public TypeCode TypeCode => _value.TypeCode;

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

        public bool TryGetObject(out object value)
        {
            if (TypeCode != TypeCode.Object)
            {
                value = default;
                return false;
            }

            value = AsObject;
            Assert(value != null, "[Property.TryGetObject] value != null");
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
            Assert(value != null, "[Property.TryGetString] value != null");
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

        public static implicit operator Property((string name, object value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, string value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, bool value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, byte value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, sbyte value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, char value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, short value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, ushort value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, int value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, uint value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, long value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, ulong value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, float value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, double value) t) => new Property(t.name, t.value);

        public static implicit operator Property((string name, DateTime value) t) => new Property(t.name, t.value);
    }
}
