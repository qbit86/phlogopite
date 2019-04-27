using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phlogopite
{
    public readonly struct Property
    {
        private readonly string _name;
        private readonly PropertyValue _value;

        internal Property(string name, PropertyValue value)
        {
            _name = name;
            _value = value;
        }

        public string Name => _name;
    }
}
