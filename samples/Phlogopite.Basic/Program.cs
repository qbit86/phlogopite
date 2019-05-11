using System;

namespace Phlogopite
{
    internal static class Program
    {
        private const string Tag = nameof(Program);

        private static void Main()
        {
            var sinks = new[] { new ConsoleSink() };
            var mediator = new Mediator(sinks);
            var log = new Writer(mediator, Tag);
            log.V("Hello, world!");
        }
    }
}
