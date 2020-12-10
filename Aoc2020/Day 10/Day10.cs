namespace Aoc2020.Day10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day10 : IDay
    {
        public string ExecutePart1(string input)
        {
            var lines = input.ToLines().Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            lines.Add(lines.Max() + 3);
            lines.Insert(0, 0);
            var gaps = new List<int>();

            for (int i = 0; i < lines.Count() - 1; i++)
            {
                gaps.Add(lines[i + 1] - lines[i]);
            }

            var ans = gaps.Count(x => x == 1) * gaps.Count(x => x == 3);

            return ans.ToString();
        }

        public string ExecutePart2(string input)
        {
            var lines = input.ToLines().Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            lines.Add(lines.Max() + 3);
            lines.Insert(0, 0);
            var gaps = new List<int>();

            for (int i = 0; i < lines.Count() - 1; i++)
            {
                gaps.Add(lines[i + 1] - lines[i]);
            }

            var possibilities = new List<long>();
            var count = 0;

            for (int i = 0; i < gaps.Count(); i++)
            {
                if (gaps[i] == 1)
                {
                    count++;
                }

                if (gaps[i] == 3)
                {
                    switch (count)
                    {
                        case 2:
                            possibilities.Add(2);
                            break;
                        case 3:
                            possibilities.Add(4);
                            break;
                        case 4:
                            possibilities.Add(7);
                            break;
                    }

                    count = 0;
                }
            }

            return possibilities.Aggregate(1L, (x, y) => x * y).ToString();
        }
    }
}
