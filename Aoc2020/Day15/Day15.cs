namespace Aoc2020.Day15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day15 : IDay
    {
        public string ExecutePart1(string input)
        {
            var numbers = input.Split(',').Select((v, i) => new { index = (long)i + 1, value = long.Parse(v) })
                .ToDictionary(x => x.value, x => x.index);

            var lastNumber = numbers.Last().Key;
            numbers.Remove(lastNumber);

            for (int i = numbers.Count() + 1; i != 2020; i++)
            {
                if (!numbers.ContainsKey(lastNumber))
                {
                    numbers[lastNumber] = i;
                    lastNumber = 0;
                }
                else
                {
                    var nextNumber = i - numbers[lastNumber];
                    numbers[lastNumber] = i;
                    lastNumber = nextNumber;
                }
            }

            return lastNumber.ToString();
        }

        public string ExecutePart2(string input)
        {
            var numbers = input.Split(',').Select((v, i) => new { index = (int)i + 1, value = int.Parse(v) })
                .ToDictionary(x => x.value, x => x.index);

            var lastNumber = numbers.Last().Key;
            numbers.Remove(lastNumber);

            for (int i = numbers.Count() + 1; i != 30000000; i++)
            {
                if (!numbers.ContainsKey(lastNumber))
                {
                    numbers[lastNumber] = i;
                    lastNumber = 0;
                }
                else
                {
                    var nextNumber = i - numbers[lastNumber];
                    numbers[lastNumber] = i;
                    lastNumber = nextNumber;
                }
            }

            return lastNumber.ToString();
        }
    }
}
