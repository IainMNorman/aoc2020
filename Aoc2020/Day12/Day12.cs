namespace Aoc2020.Day12
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class Day12 : IDay
    {
        public string ExecutePart1(string input)
        {
            var instructions = input.ToLines().Select(x => Tuple.Create(x[0], int.Parse(x.Substring(1))));

            var loc = new Vector2(0, 0);
            var compass = new Vector2[]
            {
                new Vector2(1, 0),
                new Vector2(0, -1),
                new Vector2(-1, 0),
                new Vector2(0, 1)
            };
            var dir = 0;

            foreach (var i in instructions)
            {
                switch (i.Item1)
                {
                    case 'E':
                        loc += new Vector2(i.Item2, 0);
                        break;
                    case 'S':
                        loc += new Vector2(0, -i.Item2);
                        break;
                    case 'W':
                        loc += new Vector2(-i.Item2, 0);
                        break;
                    case 'N':
                        loc += new Vector2(0, i.Item2);
                        break;
                    case 'R':
                        dir = (dir + (i.Item2 / 90)) % 4;
                        break;
                    case 'L':
                        dir = ((dir + 4) - (i.Item2 / 90)) % 4;
                        break;
                    case 'F':
                        loc += compass[dir] * i.Item2;
                        break;
                    default:
                        break;
                }
            }

            return (Math.Abs(loc.X) + Math.Abs(loc.Y)).ToString();
        }

        public string ExecutePart2(string input)
        {
            var instructions = input.ToLines().Select(x => Tuple.Create(x[0], int.Parse(x.Substring(1))));

            var loc = new Vector2(0, 0);
            var wp = new Vector2(10, 1);

            foreach (var i in instructions)
            {
                switch (i.Item1)
                {
                    case 'E':
                        wp += new Vector2(i.Item2, 0);
                        break;
                    case 'S':
                        wp += new Vector2(0, -i.Item2);
                        break;
                    case 'W':
                        wp += new Vector2(-i.Item2, 0);
                        break;
                    case 'N':
                        wp += new Vector2(0, i.Item2);
                        break;
                    case 'R':
                        for (int j = 0; j < (i.Item2 / 90); j++)
                        {
                            wp = new Vector2(wp.Y, -wp.X);
                        }

                        break;
                    case 'L':
                        for (int j = 0; j < (i.Item2 / 90); j++)
                        {
                            wp = new Vector2(-wp.Y, wp.X);
                        }

                        break;
                    case 'F':
                        loc += wp * i.Item2;
                        break;
                    default:
                        break;
                }
            }

            return (Math.Abs(loc.X) + Math.Abs(loc.Y)).ToString();
        }
    }
}
