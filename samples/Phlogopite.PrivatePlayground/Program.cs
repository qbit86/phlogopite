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

            ConsoleSink consoleSink = new ConsoleSinkBuilder { OmitLevel = true, OmitTime = true }.Build();
            var otherConsoleSink = new ConsoleSink();
            var formattedSinks = new IFormattedSink<NamedProperty>[] { consoleSink, otherConsoleSink };
            var sinks = new ISink<NamedProperty>[]
            {
                consoleSink, otherConsoleSink, new FormattingSink(formattedSinks)
            };
            var mediator = new Mediator(sinks, Level.Debug);
            Log.TrySetMediator(mediator);

            Foo();
        }

        private static void Foo()
        {
            var log = new Writer(Log.Mediator, Tag);
            log.V("Hello, World!", ("username", Environment.UserName));
            Log.D(Tag, "Anonymous property", (null, Thread.CurrentThread.CurrentCulture.Name));
            Log.Mediator.I(Tag, ("doubles", new[] { Math.E, Math.PI }));
            log.W((nameof(GC.GetAllocatedBytesForCurrentThread), GC.GetAllocatedBytesForCurrentThread()),
                (nameof(GC.GetTotalMemory), GC.GetTotalMemory(false)));
        }
    }
}
