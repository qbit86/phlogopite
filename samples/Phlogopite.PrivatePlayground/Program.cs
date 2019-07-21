using System;
using Phlogopite.Extensions.Category;
using Phlogopite.Extensions.Logger;
using Phlogopite.Extensions.Source;

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
        private static CategoryLogger<ILogger<NamedProperty, ArraySegment<NamedProperty>>> s_log;

        public Foo()
        {
            s_log = CategoryLogger.Create(Log.Logger, nameof(Foo));
        }

        internal void Bar()
        {
            Log.Logger.Write(Level.Info, nameof(Foo), "Hello", ("user", Environment.UserName));

            s_log.D("Text", ("pi", Math.PI));
        }
    }
}
