using System;
using Phlogopite.Extensions.Source;
using Phlogopite.Extensions.Tag;
using Phlogopite.Singletons.Mediator;

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
        private static CategoryLogger<MediatorLogger> s_log;

        public Foo()
        {
            s_log = CategoryLogger.Create(Log.Logger, nameof(Foo));
        }

        internal void Bar()
        {
            Log.Logger.Write(Level.Info, nameof(Foo), "Hello", ("user", Environment.UserName));
            s_log.D("(In)famous constant", ("pi", Math.PI));
            Log.Write(Level.Warning, nameof(Foo), "Text is required!", (nameof(DateTime.Now), DateTime.Now));
        }
    }
}
