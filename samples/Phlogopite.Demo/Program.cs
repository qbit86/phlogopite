using System;
using System.Globalization;
using System.Threading;

namespace Phlogopite
{
    internal static class Program
    {
        private const string Tag = nameof(Program);

        private static void Main()
        {
            // Messing with culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            var sink = new ConsoleSink();
            var mediator = new Mediator { sink };
            Mediator.Shared = mediator;
            Foo();
        }

        private static void Foo()
        {
            var log = new Writer(Mediator.Shared, Tag);
            log.V("DateTime formatting", ("dateTime", DateTime.Now));
            log.D("Anonymous property", (null, Thread.CurrentThread.CurrentCulture.Name));
            log.I("Plain text, no dynamic formatting", ("tau", 2.0 * Math.PI), ("today", DateTime.Today));
            log.W("Empty property", (null, null));
            log.E("Error!", (null, new InvalidOperationException("Just test")));
            log.A("This is fine.", new NamedProperty("ambiguous", 1729), ("unambiguous", DateTime.Now.Year));
        }
    }
}
