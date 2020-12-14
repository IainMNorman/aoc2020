namespace Aoc2020
{
    using System;
    using System.Linq;

    public static class InputHelper
    {
        public static int[] ToIntArray(this string input)
        {
            var lines = input.Split("\n").Select(str =>
            {
                int value;
                bool success = int.TryParse(str, out value);
                return new { value, success };
            })
           .Where(pair => pair.success)
           .Select(pair => pair.value)
           .ToArray();

            return lines;
        }

        public static string[] ToLines(this string input)
        {
            var lines = input.Replace("\r", string.Empty).Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(str => str)
           .ToArray();

            return lines;
        }
    }
}
