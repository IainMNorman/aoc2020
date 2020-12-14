namespace Aoc2020.Day13
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Day13 : IDay
    {
        public string ExecutePart1(string input)
        {
            var lines = input.ToLines();
            var startTime = int.Parse(lines[0]);
            var bs = lines[1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x != "x")
                .Select(x => int.Parse(x));

            var shortestWait = int.MaxValue;
            var ans = 0;

            foreach (var bus in bs)
            {
                var wait = bus - (startTime % bus);

                if (wait < shortestWait)
                {
                    ans = wait * bus;
                    shortestWait = wait;
                }
            }

            return ans.ToString();
        }

        public string ExecutePart2(string input)
        {
            var lines = input.ToLines();
            var startTime = int.Parse(lines[0]);
            var bs = lines[1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select((x, i) => Tuple.Create(i, x))
                .Where(x => x.Item2 != "x")
                .Select(x => Tuple.Create(x.Item1, int.Parse(x.Item2)))
                .ToArray();

            var t = 0L;
            var td = 1L;
            for (int i = 2; i <= bs.Length; i++)
            {
                while (this.MatchFirstN(t, bs, i) == false)
                {
                    t += td;
                }

                td = bs.Take(i).Aggregate(1L, (x, y) => x * y.Item2);
            }

            return t.ToString();
        }

        private bool MatchFirstN(long t, Tuple<int, int>[] bs, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if ((t + bs[i].Item1) % bs[i].Item2 != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
