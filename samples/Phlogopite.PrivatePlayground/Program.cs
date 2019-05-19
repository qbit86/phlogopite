using System;
using System.Globalization;
using System.Threading;
using Phlogopite.Extensions;
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

            ConsoleSink concoleSink = new ConsoleSinkBuilder { IsSynchronized = true }.Build();
            var formattedSinks = new IFormattedSink<NamedProperty>[] { concoleSink };
            var sinks = new ISink<NamedProperty>[] { new FormattingSink(formattedSinks) };
            var mediator = new Mediator(sinks, Level.Debug);
            Log.TrySetMediator(mediator);

            Foo();
        }

        private static void Foo()
        {
            var log = new Writer(Log.Mediator, Tag);
            log.V("Hello, World!", ("username", Environment.UserName));
            log.D("Anonymous property", (null, Thread.CurrentThread.CurrentCulture.Name));
            Log.Mediator.I(Tag, "Plain text", (nameof(Math.E), Math.E), ("today", DateTime.Today));
            log.W("Empty property", (null, null));
            Log.Mediator.E(Tag, ("byte", (byte)0xfa), ("decimal", 1.618m));
            log.A("This is fine.", new NamedProperty("ambiguous", 1729), ("unambiguous", DateTime.Now.Year));
            log.I(null, ("strings", new[] { "apple", "orange" }), ("doubles", new[] { Math.E, Math.PI }),
                ("decimals", new[] { 3.5m, 5.8m, 8.13m }),
                ("decimalsAsObjects", new[] { (object)3.5m, (object)5.8m, (object)8.13m }));
            log.Write(Level.Error, "Testing checked Write()", default);
            Log.Write(Level.Info, Tag, "Testing Log.Write()");
            log.I((nameof(GC.GetAllocatedBytesForCurrentThread), GC.GetAllocatedBytesForCurrentThread()),
                (nameof(GC.GetTotalMemory), GC.GetTotalMemory(false)));
            try
            {
                throw new InvalidOperationException("Just test");
            }
            catch (InvalidOperationException ex)
            {
                log.E((null, ex));
            }
        }
    }
}
