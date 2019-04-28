using System;

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            ISink<NamedProperty> sink = new ConsoleSink(Level.Verbose);
            var mediator = new Mediator(Level.Verbose);
            mediator.Add(sink);
            var log = new Writer(mediator, nameof(Program) + "." + nameof(Main), Level.Verbose);
            log.V("Hello verbose", ("userProperty", DateTime.Now));
        }
    }
}
