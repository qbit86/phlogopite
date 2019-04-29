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

        internal void Render(float value)
        {
            Span<char> stackBuffer = stackalloc char[128];

            if (value.TryFormat(stackBuffer, out int formattedLength, default, _formatProvider))
            {
                ReadOnlySpan<char> utf16Text = stackBuffer.Slice(0, formattedLength);
                _output.Write(utf16Text);
            }
            else
            {
                _output.Write(value.ToString(_formatProvider));
            }
        }
    }
}
