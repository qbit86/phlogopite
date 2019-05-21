using System;
using System.Net;
using Phlogopite.Extensions;
using Phlogopite.Sinks;

namespace Phlogopite
{
    internal static class Program
    {
        private const string Tag = nameof(Program);

        private static void Main()
        {
            var sink = new ConsoleSink();
            var mediator = new Mediator(sink);

            var log = new Writer(mediator, Tag);
            log.V("Hello, world!");
            log.I("Logged in", ("username", Environment.UserName), ("ipaddress", IPAddress.Loopback));
        }
    }
}
