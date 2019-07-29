using System;
using Phlogopite.Extensions.Source;
using Phlogopite.Extensions.Tag;
using Phlogopite.Singletons;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            MediatorLogger m = new MediatorLoggerBuilder(Level.Debug).AddLogger(new ConsoleLogger()).Build();
            Log.TrySetLogger(m);

            var foo = new Foo();
            foo.Bar();
        }
    }

    internal sealed class Foo
    {
        private static CategoryLogger<ILogger<NamedProperty>> s_logger;

        private static CategoryLogger<ILogger<NamedProperty>> L => s_logger.IsDefault
            ? s_logger = CategoryLogger.Create(Log.Logger, nameof(Foo))
            : s_logger;

        internal void Bar()
        {
            Log.Logger.Write(Level.Info, nameof(Foo), "Hello", ("user", Environment.UserName));
            L.D("(In)famous constant", ("pi", Math.PI));
            Log.W(nameof(Foo), "Text is required!", (nameof(DateTime.Now), DateTime.Now));
        }
    }
}
