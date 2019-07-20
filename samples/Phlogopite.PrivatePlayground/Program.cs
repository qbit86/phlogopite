using System;
using System.Globalization;
using System.Threading;
using Phlogopite.Extensions.Category;
using Phlogopite.Extensions.Mediator;

#pragma warning disable CA1303

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            // Messing with culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            MediatorLogger m = new MediatorLoggerBuilder(Level.Debug).AddLogger(new ConsoleLogger()).Build();
            Log.TrySetLogger(m);

            var foo = new Foo();
            foo.Bar();
        }
    }

    internal sealed class Foo
    {
        internal void Bar()
        {
            Log.Logger.Write(Level.Info, nameof(Program), "Hello", ("user", Environment.UserName));
        }
    }
}
