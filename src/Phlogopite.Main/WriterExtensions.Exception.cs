using System;

namespace Phlogopite
{
    public static partial class WriterExtensions
    {
        public static void Exception<TWriter>(this TWriter writer, Exception ex)
            where TWriter : IWriter<NamedProperty>
        {
            if (!writer.IsEnabled(Level.Error))
                return;

            WriteUnchecked(writer, Level.Error, null, new NamedProperty(null, ex));
        }
    }
}
