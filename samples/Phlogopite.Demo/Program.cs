using System;
using static System.Diagnostics.Debug;

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
            Assert(mediator != null, $"[{tag}] mediator != null");

            var log = new Writer(mediator, tag);
            log.V("Hello verbose", ("userProperty", DateTime.Now));
        }
    }
}
