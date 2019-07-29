using System;
using Phlogopite;
using Phlogopite.Extensions.Source;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Samples
{
    internal static class Program
    {
        private static void Main()
        {
            var backLogger = new ConsoleLogger();
            var frontLogger = new CategoryLogger(backLogger, nameof(Program));

            frontLogger.I("Hello!", ("user", Environment.UserName));
        }
    }
}
