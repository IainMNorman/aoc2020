namespace Aoc2020.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AoC2020.Day11;

    public class Day11 : IDay
    {
        public string ExecutePart1(string input)
        {
////            input = @"L.LL.LL.LL
////LLLLLLL.LL
////L.L.L..L..
////LLLL.LL.LL
////L.LL.LL.LL
////L.LLLLL.LL
////..L.L.....
////LLLLLLLLLL
////L.LLLLLL.L
////L.LLLLL.LL".Replace("\r", string.Empty);

            var life = new Life(input);

            var genHash = life.Render();

            while (true)
            {
                life.Generatation();
                if (genHash == life.Render())
                {
                    break;
                }

                genHash = life.Render();
            }

            return life.OccupiedSeats().ToString();
        }

        public string ExecutePart2(string input)
        {
////            input = @"
////L.LL.LL.LL
////LLLLLLL.LL
////L.L.L..L..
////LLLL.LL.LL
////L.LL.LL.LL
////L.LLLLL.LL
////..L.L.....
////LLLLLLLLLL
////L.LLLLLL.L
////L.LLLLL.LL".Replace("\r", string.Empty);

            var life = new Life2(input);

            var genHash = life.Render();

            while (true)
            {
                life.Generatation();
                if (genHash == life.Render())
                {
                    break;
                }

                genHash = life.Render();
            }

            return life.OccupiedSeats().ToString();
        }
    }
}
