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
    }
}
