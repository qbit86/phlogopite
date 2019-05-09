using System;
using System.Text;
using static System.Diagnostics.Debug;

namespace Phlogopite
{
    internal readonly struct StringBuilderFacade
    {
        private readonly StringBuilder _sb;
        private readonly IFormatProvider _formatProvider;

        public StringBuilderFacade(StringBuilder sb, IFormatProvider formatProvider)
        {
            Assert(sb != null);
            _sb = sb;

            Assert(formatProvider != null);
            _formatProvider = formatProvider;
        }
    }
}
