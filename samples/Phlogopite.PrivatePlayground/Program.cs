using System.Globalization;
using System.Threading;

namespace Phlogopite
{
    internal static class Program
    {
        private static void Main()
        {
            // Messing with culture.
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");

            var foo = new Foo();
            foo.Bar();
        }
    }

    internal sealed class Foo
    {
        internal void Bar()
        {
        }
    }
}
