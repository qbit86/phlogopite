using System;
using Phlogopite;
using Phlogopite.Extensions.Source;
using Phlogopite.Singletons;

#pragma warning disable CA1303 // Do not pass literals as localized parameters

namespace Samples
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
        private static readonly Lazy<CategoryLogger> s_logger =
            new Lazy<CategoryLogger>(() => new CategoryLogger(Log.Logger, nameof(Foo)));

        private static CategoryLogger L => s_logger.Value;

        internal void Bar()
        {
            L.I("Hello!", (nameof(Environment.UserName), Environment.UserName));
        }
    }
}
