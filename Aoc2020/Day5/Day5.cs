namespace Aoc2020.Day5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Aoc2020.Helpers;

    public class Day5 : IDay
    {
        public string ExecutePart1(string input)
        {
            var passes = input.ToStringArray();

            return passes.Select(x => this.PassToSeatId(x)).Max().ToString();
        }

        public string ExecutePart2(string input)
        {
            var passes = input.ToStringArray();
            var ints = passes.Select(x => this.PassToSeatId(x)).ToList();
            ints.Sort();

            var missing = Enumerable.Range(ints.Min(), ints.Count)
                .Except(ints).First();

            return missing.ToString();
        }

        public int PassToSeatId(string pass)
        {
            pass = pass
                .Replace('F', '0')
                .Replace('B', '1')
                .Replace('L', '0')
                .Replace('R', '1');

            return Convert.ToInt32(pass, 2);
        }
    }
}
