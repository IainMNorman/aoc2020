namespace Aoc2020.Day3
{
    using System;

    public class Day3 : IDay
    {
        public string ExecutePart1(string input)
        {
            return this.GetTreesHit(input, 3, 1).ToString();
        }

        public int GetTreesHit(string input, int dx, int dy)
        {
            var map = new Map(input);

            var hit = 0;

            while (map.Cursor.Y < map.Height)
            {
                if (map.Cell(map.Cursor) == '#')
                {
                    hit++;
                }

                map.Move(dx, dy);
            }

            return hit;
        }

        public string ExecutePart2(string input)
        {
            var total = 1L;
            total *= this.GetTreesHit(input, 1, 1);
            total *= this.GetTreesHit(input, 3, 1);
            total *= this.GetTreesHit(input, 5, 1);
            total *= this.GetTreesHit(input, 7, 1);
            total *= this.GetTreesHit(input, 1, 2);

            return total.ToString();
        }
    }
}
