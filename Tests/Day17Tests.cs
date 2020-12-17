using Aoc2020.Day17;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests
{
    public class Day17Tests
    {
        private Day17 day;

        public Day17Tests()
        {
            this.day = new Day17();
        }

        [Fact]
        public void Part1Test1()
        {
            var life = new LifeCube(".#.\n..#\n###");
            for (int i = 0; i < 6; i++)
            {
                life.Generation();
            }

            life.Population.ShouldBe(112);
        }

        [Fact]
        public void Part2Test1()
        {
            var life = new LifeCube4(".#.\n..#\n###");
            for (int i = 0; i < 6; i++)
            {
                life.Generation();
            }

            life.Population.ShouldBe(848);
        }
    }
}
