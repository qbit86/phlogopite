#if NET20 || NET35 || NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#elif NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#elif NETCOREAPP1_0 || NETCOREAPP1_1 || NETCOREAPP2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#endif

using System;
using System.Text;
using static System.Diagnostics.Debug;

namespace Phlogopite
{
    internal readonly struct StringBuilderFacade
    {
        private readonly StringBuilder _sb;
        private readonly IFormatProvider _formatProvider;

        internal StringBuilderFacade(StringBuilder sb, IFormatProvider formatProvider)
        {
            Assert(sb != null);
            _sb = sb;

            Assert(formatProvider != null);
            _formatProvider = formatProvider;
        }

        internal void Append(bool value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _sb.Append(value);
#else
            Span<char> buffer = stackalloc char[5];
            if (value.TryFormat(buffer, out int charsWritten))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, charsWritten);
                _sb.Append(utf16Text);
            }
            else
            {
                _sb.Append(value);
            }
#endif
        }
    }
}
