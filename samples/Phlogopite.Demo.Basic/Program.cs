using System;
using Phlogopite.Extensions.Source;
using Phlogopite.Singletons;
using Cat = Phlogopite.CategoryLogger;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            var logger = new ConsoleLogger(Level.Debug);
            Log.TrySetLogger(logger);

            var foo = new Foo();
            foo.Bar();
        }
    }

    internal sealed class Foo
    {
        private static readonly Lazy<Cat> s_logger = new Lazy<Cat>(() => new Cat(Log.Logger, nameof(Foo)));

        private static Cat L => s_logger.Value;

        internal void Bar()
        {
            L.I("Hello!", (nameof(Environment.UserName), Environment.UserName));
        }
    }
}
