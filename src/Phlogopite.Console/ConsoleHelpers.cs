using System;

namespace Phlogopite
{
    internal static class ConsoleHelpers
    {
        private static readonly ConsoleColor[] s_levelColorMap =
        {
            ConsoleColor.DarkGray, ConsoleColor.Gray, ConsoleColor.White, ConsoleColor.DarkYellow, ConsoleColor.Red,
            ConsoleColor.DarkRed, ConsoleColor.Cyan
        };

        internal static ConsoleColor SetForegroundColor(Level level)
        {
            if ((uint)level >= (uint)s_levelColorMap.Length)
                return Console.ForegroundColor;

            return SetForegroundColor(s_levelColorMap[(int)level]);
        }

        private static ConsoleColor SetForegroundColor(ConsoleColor color)
        {
            ConsoleColor result = Console.ForegroundColor;
            Console.ForegroundColor = color;
            return result;
        }
    }
}
