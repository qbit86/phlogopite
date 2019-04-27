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

        public string Name => _name;
    }
}
