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
            1.ShouldBe(1);
        }
        
    }
}
