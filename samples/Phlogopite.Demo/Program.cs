using System;

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            var sink = new ConsoleSink();
            var mediator = new Mediator();
            mediator.Add(sink);
            Foo(mediator);
        }

        private static void Foo(Mediator mediator)
        {
            const string tag = nameof(Program) + "." + nameof(Foo);
            var log = new Writer(mediator, tag);
            log.V("Hello verbose", ("dateTime", DateTime.Now));
            log.D("Anonymous property", (null, Environment.CurrentDirectory));
            log.I("Here is float!", ("float", 1.618f));
        }
    }
}
