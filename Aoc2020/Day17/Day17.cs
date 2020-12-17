namespace Aoc2020.Day17
{
    using System;

    public class Day17 : IDay
    {
        public string ExecutePart1(string input)
        {
            var life = new LifeCube(input);
            for (int i = 0; i < 6; i++)
            {
                life.Generation();
            }

            return life.Population.ToString();
        }

        public string ExecutePart2(string input)
        {
            var life = new LifeCube4(input);
            for (int i = 0; i < 6; i++)
            {
                life.Generation();
            }

            return life.Population.ToString();
        }
    }
}
