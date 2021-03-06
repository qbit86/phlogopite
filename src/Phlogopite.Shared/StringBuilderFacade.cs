#if NET461 || NETSTANDARD1_3 || NETSTANDARD2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#endif

using System;
using System.Text;
using static System.Diagnostics.Debug;

namespace Phlogopite
{
    internal readonly struct StringBuilderFacade
    {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
        private const int CharStackBufferSize = 32;
#endif

        private readonly StringBuilder _sb;
        private readonly IFormatProvider _formatProvider;

        internal StringBuilderFacade(StringBuilder sb, IFormatProvider formatProvider)
        {
            Assert(sb != null);
            _sb = sb;

            Assert(formatProvider != null);
            _formatProvider = formatProvider;
        }

        internal void Append(object value)
        {
            string s = Convert.ToString(value, _formatProvider);
            _sb.Append(s);
        }

        internal void Append(string value)
        {
            _sb.Append(value);
        }

        internal void Append(char value)
        {
            _sb.Append(value);
        }

        internal void Append(bool value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[5];
            if (value.TryFormat(buffer, out int charsWritten))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value);
        }

        internal void Append(sbyte value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(sbyte value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(byte value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(byte value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(short value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(short value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(ushort value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(ushort value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(int value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(int value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(uint value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(uint value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(long value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(long value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(ulong value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(ulong value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(float value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(float value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(double value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(double value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }

        internal void Append(DateTime value)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, default, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(_formatProvider));
        }

        internal void Append(DateTime value, string format)
        {
#if !PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            Span<char> buffer = stackalloc char[CharStackBufferSize];
            if (value.TryFormat(buffer, out int charsWritten, format, _formatProvider))
            {
                _sb.Append(buffer.Slice(0, charsWritten));
                return;
            }
#endif

            _sb.Append(value.ToString(format, _formatProvider));
        }
    }
}
