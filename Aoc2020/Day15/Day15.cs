namespace Aoc2020.Day15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day15 : IDay
    {
        public string ExecutePart1(string input)
        {
            var numbers = input.Split(',').Select((v, i) => new { index = (long)i, value = long.Parse(v) })
                .ToDictionary(x => x.index, x => x.value);

            var count = numbers.Count();

            for (int i = count; i < 2020; i++)
            {
                var lastNumber = numbers[i - 1];

                if (numbers.Count(x => x.Value == lastNumber) == 1)
                {
                    numbers.Add(i, 0);
                }
                else
                {
                    var lastTwo = numbers.Where(x => x.Value == lastNumber).OrderByDescending(x => x.Key).Take(2).ToArray();

                    var newNumber = lastTwo[0].Key - lastTwo[1].Key;
                    numbers.Add(i, newNumber);
                }
            }

            return numbers[2019].ToString();
        }

        public string ExecutePart2(string input)
        {
            var numbers = input.Split(',').Select((v, i) => new { index = (long)i, value = long.Parse(v) })
                .ToDictionary(x => x.value, x => x.index);

            var lastNumber = numbers.Last().Key;

            for (int i = numbers.Count(); i < 2020; i++)
            {
                if (numbers[lastNumber] == i - 1)
                {
                    lastNumber = 0;
                }
                else
                {
                    var newNumber = i - 1 - numbers[lastNumber];
                    numbers[lastNumber] = i - 1;
                    numbers[newNumber] = i;
                    lastNumber = newNumber;
                }
            }

            return lastNumber.ToString();
        }
    }
}
