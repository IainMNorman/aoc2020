namespace Aoc2020.Day6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day6 : IDay
    {
        public string ExecutePart1(string input)
        {
            var p1 = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Replace("\n", string.Empty).ToCharArray().GroupBy(g => g))
                .Sum(x => x.Count());

            return p1.ToString();
        }

        public string ExecutePart2(string input)
        {
            var p2 = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(group => group.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                    .Select(person => person.ToCharArray())
                    .Aggregate<IEnumerable<char>>((prev, next) => prev.Intersect(next)).ToList())
                .Sum(x => x.Count);

            return p2.ToString();
        }
    }
}
