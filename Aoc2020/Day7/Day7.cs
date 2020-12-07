namespace Aoc2020.Day6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Rivers;

    public class Day7 : IDay
    {
        public string ExecutePart1(string input)
        {
            var graph = this.ProcessInput(input);
            var p1 = graph.Keys.Count(x => this.ContainsKeyRecurse(graph, x, "shiny gold"));
            return p1.ToString();
        }

        public string ExecutePart2(string input)
        {
            var graph = this.ProcessInput(input);
            var p2 = CountSubBags("shiny gold", graph);
            return p2.ToString();
        }

        private static int CountSubBags(string colour, Dictionary<string, Dictionary<string, int>> graph)
        {
            return graph[colour].Sum(x => x.Value * (1 + CountSubBags(x.Key, graph)));
        }

        private bool ContainsKeyRecurse(Dictionary<string, Dictionary<string, int>> graph, string bagName, string myBag)
        {
            return graph[bagName].ContainsKey(myBag) ||
                graph[bagName].Keys.Any(x => this.ContainsKeyRecurse(graph, x, myBag));
        }

        private Dictionary<string, Dictionary<string, int>> ProcessInput(string input)
        {
            var re = new Regex(@"(.*?) bags contain(?: (\d+ .*?) bag(?:s)?[,.])*");

            return input.ToStringArray().Select(x => re.Match(x)).ToDictionary(
                    x => x.Groups[1].Value,
                    x => x.Groups[2].Captures.OfType<Capture>()
                        .Select(x => x.Value.Split(new[] { ' ' }, 2))
                        .ToDictionary(x => x[1], x => int.Parse(x[0])));
        }
    }
}
