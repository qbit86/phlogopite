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
            ConsoleLogger c0 = new ConsoleLoggerBuilder { EmitTime = true }.Build();
            ConsoleLogger c1 = new ConsoleLoggerBuilder
                { EmitTime = true, Formatter = new SampleFormatter("!1@") }.Build();
            ConsoleLogger c2 = new ConsoleLoggerBuilder
                { EmitTime = true, Formatter = new SampleFormatter("@2#") }.Build();
            ConsoleLogger c3 = new ConsoleLoggerBuilder
                { EmitTime = true, Formatter = new SampleFormatter("#3$") }.Build();

            FormattingLogger f0 = new FormattingLoggerBuilder().AddLoggers(c0, c2).Build();
            FormattingLogger f4 = new FormattingLoggerBuilder { Formatter = new SampleFormatter("$4%") }
                .AddLoggers(c0, c3).Build();

            var loggers = new ILogger<NamedProperty>[] { c0, c1 };
            MediatorLogger m = new MediatorLoggerBuilder(loggers, Level.Debug).AddLoggers(f0, f4).Build();
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
