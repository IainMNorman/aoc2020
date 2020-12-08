namespace Aoc2020.Day2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day2 : IDay
    {
        public string ExecutePart1(string input)
        {
            var passwords = this.ProcessInput(input);

            var validCount = passwords.Count(x => this.IsPasswordValid(x.Item1, x.Item2, x.Item3, x.Item4));

            return validCount.ToString();
        }

        public string ExecutePart2(string input)
        {
            var passwords = this.ProcessInput(input);

            var validCount = passwords.Count(x => this.IsPasswordValid2(x.Item1, x.Item2, x.Item3, x.Item4));

            return validCount.ToString();
        }

        public bool IsPasswordValid(int min, int max, string compulsory, string password)
        {
            var compCount = Regex.Matches(password, compulsory).Count;
            if (compCount >= min && compCount <= max)
            {
                return true;
            }

            return false;
        }

        public bool IsPasswordValid2(int min, int max, string compulsory, string password)
        {
            return password[min - 1].ToString() == compulsory ^ password[max - 1].ToString() == compulsory;
        }

        public List<(int, int, string, string)> ProcessInput(string input)
        {
            var lines = input.ToLines();
            var list = lines.Select(
                x => (
                    int.Parse(Regex.Match(x, "^(.*?)-").Groups[1].Value),
                    int.Parse(Regex.Match(x, "-(.*?) ").Groups[1].Value),
                    Regex.Match(x, " (.):").Groups[1].Value,
                    Regex.Match(x, ": (.*?)$").Groups[1].Value))
                .ToList();
            return list;
        }
    }
}
