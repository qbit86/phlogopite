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

            _formatProvider = formatProvider;
        }

        internal void Render(bool value)
        {
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
        }

        internal void Render(sbyte value)
        {
            Span<char> buffer = stackalloc char[4];
            if (value.TryFormat(buffer, out int formattedLength, "X2", _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
        }

        internal void Render(byte value)
        {
            Span<char> buffer = stackalloc char[4];
            if (value.TryFormat(buffer, out int formattedLength, "X2", _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = buffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
        }

        internal void Render(short value)
        {
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
        }

        internal void Render(ushort value)
        {
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
        }

        internal void Render(int value)
        {
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
        }

        internal void Render(uint value)
        {
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
        }

        internal void Render(long value)
        {
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
        }

        internal void Render(ulong value)
        {
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
        }

        internal void Render(float value)
        {
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
        }

        internal void Render(double value)
        {
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
        }

        internal void Render(DateTime value)
        {
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
        }
    }
}
