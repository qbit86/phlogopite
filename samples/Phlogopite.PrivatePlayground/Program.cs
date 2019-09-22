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
            ConsoleLogger consoleLoggerWithDefaultFormatter = new ConsoleLoggerBuilder { EmitTime = true }.Build();
            ConsoleLogger consoleLoggerWithFancyFormatter = new ConsoleLoggerBuilder
                { EmitTime = true, Formatter = SampleFormatter.Default }.Build();
            var loggers = new ILogger<NamedProperty>[]
                { consoleLoggerWithDefaultFormatter, consoleLoggerWithFancyFormatter };
            FormattingLogger formattingLoggerWithDefaultFormatter = new FormattingLoggerBuilder(loggers).Build();
            FormattingLogger formattingLoggerWithFancyFormatter = new FormattingLoggerBuilder(loggers)
                { Formatter = SampleFormatter.Default }.Build();
            MediatorLogger m = new MediatorLoggerBuilder(loggers, Level.Debug)
                .AddLoggers(formattingLoggerWithDefaultFormatter, formattingLoggerWithFancyFormatter).Build();
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
