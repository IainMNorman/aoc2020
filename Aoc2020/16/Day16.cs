namespace Aoc2020.Day16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Day16 : IDay
    {
        public string ExecutePart1(string input)
        {
            var sections = input.Split("\n\n");

            var fieldsRe = new Regex(@"(.*?): (\d+)-(\d+) or (\d+)-(\d+)");

            var fields = sections[0].ToLines().Select(x => fieldsRe.Match(x))
                .Select(m => new Field
                {
                    Name = m.Groups[1].Value,
                    Range1Min = int.Parse(m.Groups[2].Value),
                    Range1Max = int.Parse(m.Groups[3].Value),
                    Range2Min = int.Parse(m.Groups[4].Value),
                    Range2Max = int.Parse(m.Groups[5].Value),
                });

            var nearbys = sections[2].ToLines().Skip(1).Select(x => x.Split(','))
                .Select(y => y.Select(z => int.Parse(z)));

            var invalids = new List<int>();

            foreach (var nearby in nearbys)
            {
                foreach (var value in nearby)
                {
                    if (!fields.Any(x => x.IsValidValue(value)))
                    {
                        invalids.Add(value);
                    }
                }
            }

            return invalids.Sum(x => x).ToString();
        }

        public string ExecutePart2(string input)
        {
            var sections = input.Split("\n\n");

            var fieldsRe = new Regex(@"(.*?): (\d+)-(\d+) or (\d+)-(\d+)");

            var fields = sections[0].ToLines().Select(x => fieldsRe.Match(x))
                .Select(m => new Field
                {
                    Name = m.Groups[1].Value,
                    Range1Min = int.Parse(m.Groups[2].Value),
                    Range1Max = int.Parse(m.Groups[3].Value),
                    Range2Min = int.Parse(m.Groups[4].Value),
                    Range2Max = int.Parse(m.Groups[5].Value),
                });

            var nearbys = sections[2].ToLines().Skip(1).Select(x => x.Split(','))
                .Select(y => y.Select(z => int.Parse(z)).ToList()).ToList();

            var myTicket = sections[1].ToLines().Skip(1).First().Split(',')
                .Select(x => int.Parse(x)).ToList();

            var invalids = new List<int>();

            foreach (var nearby in nearbys.Reverse<List<int>>())
            {
                var valid = true;
                foreach (var value in nearby)
                {
                    if (!fields.Any(x => x.IsValidValue(value)))
                    {
                        valid = false;
                    }
                }

                if (!valid)
                {
                    nearbys.Remove(nearby);
                }
            }

            var fieldMappings = new Dictionary<int, List<string>>();

            for (int i = 0; i < nearbys[0].Count(); i++)
            {
                fieldMappings[i] = new List<string>();
                var col = nearbys.Select(x => x[i]);

                foreach (var field in fields)
                {
                    if (col.All(x => field.IsValidValue(x)))
                    {
                        fieldMappings[i].Add(field.Name);
                    }
                }
            }

            var finalMappings = new Dictionary<int, string>();

            while (fieldMappings.Any(x => x.Value.Count > 0))
            {
                var firstMapping = fieldMappings.Where(x => x.Value.Count > 0)
                    .OrderBy(x => x.Value.Count).First();
                var key = firstMapping.Key;
                var field = firstMapping.Value.First();
                finalMappings.Add(key, field);
                foreach (var fieldList in fieldMappings)
                {
                    fieldList.Value.Remove(field);
                }
            }

            var departureMappings = finalMappings.Where(x => x.Value.ToLower().Contains("departure"));
            var output = 1L;
            foreach (var item in departureMappings)
            {
                output *= myTicket[item.Key];
            }

            return output.ToString();
        }

        public class Field
        {
            public string Name { get; set; }

            public int Range1Min { get; set; }

            public int Range1Max { get; set; }

            public int Range2Min { get; set; }

            public int Range2Max { get; set; }

            public bool IsValidValue(int value)
            {
                if ((value >= this.Range1Min && value <= this.Range1Max) ||
                    (value >= this.Range2Min && value <= this.Range2Max))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
