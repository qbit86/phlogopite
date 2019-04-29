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

        internal void Render(float value)
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
