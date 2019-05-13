using System;
using System.Globalization;
using System.Threading;
using Phlogopite.Sinks;

namespace Phlogopite
{
    internal static class Program
    {
        private const string Tag = nameof(Program);

        private static void Main()
        {
            // Messing with culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            var formattedSinks = new IFormattedSink<NamedProperty>[] { new ConsoleSink() };
            var sinks = new ISink<NamedProperty>[] { new FormattingSink(formattedSinks) };
            var mediator = new Mediator(sinks);
            Mediator.TrySetShared(mediator);

            Foo();
        }

        private static void Foo()
        {
            var log = new Writer(Mediator.Shared, Tag);
            log.V("Hello, World!", ("username", Environment.UserName));
            log.D("Anonymous property", (null, Thread.CurrentThread.CurrentCulture.Name));
            log.I("Plain text, no dynamic formatting", (nameof(Math.E), Math.E), ("today", DateTime.Today));
            log.W("Empty property", (null, null));
            log.E(null, ("byte", (byte)0xfa), ("decimal", 1.618m));
            log.A("This is fine.", new NamedProperty("ambiguous", 1729), ("unambiguous", DateTime.Now.Year));
            try
            {
                throw new InvalidOperationException("Just test");
            }
            catch (InvalidOperationException ex)
            {
                log.Exception(ex);
            }

            log.I(null, ("array", new[] { Math.E, Math.PI }));
        }
    }
}
