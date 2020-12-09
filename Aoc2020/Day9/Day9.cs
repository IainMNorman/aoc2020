namespace Aoc2020.Day9
{
    using System;
    using System.Linq;

    public class Day9 : IDay
    {
        public string ExecutePart1(string input)
        {
            var lines = input.ToLines().Select(x => long.Parse(x)).ToList();

            for (int i = 25; i < lines.Count(); i++)
            {
                var header = lines.Skip(i - 25).Take(25);
                var isValid = header
                    .SelectMany(x => header, (x, y) => Tuple.Create(x, y))
                    .Where(t => t.Item1 < t.Item2)
                    .Any(t => t.Item1 + t.Item2 == lines[i]);

                if (!isValid)
                {
                    return lines[i].ToString();
                }
            }

            return "Did not find";
        }

        public string ExecutePart2(string input)
        {
            var target = 731031916;

            var lines = input.ToLines().Select(x => long.Parse(x)).ToList();

            var startIdx = 0;

            while (true)
            {
                var total = 0L;
                for (int i = startIdx; i < lines.Count(); i++)
                {
                    total += lines[i];
                    if (total == target)
                    {
                        return (lines.Skip(startIdx).Take(i - startIdx).Max() +
                            lines.Skip(startIdx).Take(i - startIdx).Min()).ToString();
                    }

                    if (total > target)
                    {
                        break;
                    }
                }

                startIdx++;
            }
        }
    }
}
