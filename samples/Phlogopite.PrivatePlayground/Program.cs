using System;
using Phlogopite;
using Phlogopite.Extensions.Source;
using Phlogopite.Extensions.Tag;
using Phlogopite.Singletons;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Samples
{
    internal static class Program
    {
        private static void Main()
        {
            ConsoleLogger consoleLogger = new ConsoleLoggerBuilder { EmitTime = true }.Build();
            // MediatorLogger m = new MediatorLoggerBuilder(Level.Debug).AddLogger(consoleLogger).Build();
            TimeLogger<ConsoleLogger> m = TimeLogger.Create(consoleLogger);
            Log.TrySetLogger(m);

            var foo = new Foo();
            foo.Bar();
        }
    }

    internal sealed class Foo
    {
        private static CategoryLogger s_logger;

        private static CategoryLogger L => s_logger.IsDefault
            ? s_logger = new CategoryLogger(Log.Logger, nameof(Foo))
            : s_logger;

        internal void Bar()
        {
            Log.Logger.Write(Level.Info, nameof(Foo), "Writing to global Log.Logger", ("user", Environment.UserName));
            Log.W(nameof(Foo), "Warning via static Log.W()!", (nameof(DateTime.Now), DateTime.Now));
            L.D("Writing to instance with captured category", ("pi", Math.PI));
        }
    }
}
