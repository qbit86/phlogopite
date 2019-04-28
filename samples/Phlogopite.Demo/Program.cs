using System;
using System.Globalization;
using System.Threading;

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            // Messing with culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            var sink = new ConsoleSink();
            var mediator = new Mediator();
            mediator.Add(sink);
            Foo(mediator);
        }

        private static void Foo(Mediator mediator)
        {
            const string tag = nameof(Program) + "." + nameof(Foo);
            var log = new Writer(mediator, tag);
            log.V("DateTime formatting", ("dateTime", DateTime.Now));
            log.D("Anonymous property", (null, Thread.CurrentThread.CurrentCulture.Name));
            log.I("Here is float!", ("float", 1.618f));
            log.W("Empty property", (null, null));
            log.E("Error!", (null, new InvalidOperationException("Just test")));
            log.F("This is fine.", ("integer", 1729u));
        }
    }
}
