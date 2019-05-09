#if NET35 || NET40 || NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#elif NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#elif NETCOREAPP1_0 || NETCOREAPP1_1 || NETCOREAPP2_0
#define PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
#endif

using System;
using System.IO;
using static System.Diagnostics.Debug;

namespace Phlogopite
{
    internal readonly struct Renderer
    {
        private readonly TextWriter _output;
        private readonly IFormatProvider _formatProvider;

        internal Renderer(TextWriter output, IFormatProvider formatProvider)
        {
            Assert(output != null);
            _output = output;

            Assert(formatProvider != null);
            _formatProvider = formatProvider;
        }

        internal void Render(bool value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value);
#else
            Span<char> buffer = stackalloc char[8];
            if (value.TryFormat(buffer, out int formattedLength))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(sbyte value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[8];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(sbyte value, string format)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(format, _formatProvider));
#else
            Span<char> buffer = stackalloc char[8];
            if (value.TryFormat(buffer, out int formattedLength, format, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(byte value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[8];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(byte value, string format)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(format, _formatProvider));
#else
            Span<char> buffer = stackalloc char[8];
            if (value.TryFormat(buffer, out int formattedLength, format, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(short value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[16];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(ushort value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[16];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(int value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[32];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(uint value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[32];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(long value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[64];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(ulong value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[64];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(float value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[64];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(double value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[128];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(DateTime value)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(_formatProvider));
#else
            Span<char> buffer = stackalloc char[64];
            if (value.TryFormat(buffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }

        internal void Render(DateTime value, string format)
        {
#if PHLOGOPITE_TRY_FORMAT_NOT_SUPPORTED
            _output.Write(value.ToString(format, _formatProvider));
#else
            Span<char> buffer = stackalloc char[64];
            if (value.TryFormat(buffer, out int formattedLength, format, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
#endif
        }
    }
}
