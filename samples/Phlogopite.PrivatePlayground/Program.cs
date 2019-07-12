using System;
using System.Globalization;
using System.Threading;
using Phlogopite.Extensions;
using Phlogopite.Sinks;

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            // Messing with culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            ConsoleSink consoleSink = new ConsoleSinkBuilder { EmitLevel = true, EmitTime = true }.Build();

            Mediator mediator = new MediatorBuilder { MinimumLevel = Level.Debug }
                .AddSink(consoleSink)
                .Build();
            _ = Log.TrySetMediator(mediator);

            var foo = new Foo();
            foo.Bar();
        }
    }

    internal sealed class Foo
    {
        private readonly WriterBuilder _log;

        internal Foo(IMediator<NamedProperty> mediator = null)
        {
            _log = new WriterBuilder(mediator ?? Log.Mediator, Level.Info, nameof(Foo));
        }

        internal void Bar()
        {
            _log.V("This should be disabled by mediator");
            _log.D("This should be disabled by writer");
            _log.I("Testing things", ("username", Environment.UserName), (nameof(Math.E), Math.E));
        }
    }
}
