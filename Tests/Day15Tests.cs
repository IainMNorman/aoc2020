using Aoc2020;
using Aoc2020.Day15;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests
{
    public class Day15Tests
    {
        private Day15 day;

        public Day15Tests()
        {
            this.day = new Day15();
        }

        [Fact]
        public void Part1Test1()
        {
            day.ExecutePart1("0,3,6").ShouldBe("436");
        }

        [Fact]
        public void Part1Test2()
        {
            day.ExecutePart1("2,1,3").ShouldBe("10");
        }

        [Fact]
        public void Part1Test3()
        {
            day.ExecutePart1("1,2,3").ShouldBe("27");
        }

        [Fact]
        public void Part1Test4()
        {
            day.ExecutePart1("2,3,1").ShouldBe("78");
        }

        [Fact]
        public void Part1Test5()
        {
            day.ExecutePart1("3,2,1").ShouldBe("438");
        }

        [Fact]
        public void Part1Test6()
        {
            day.ExecutePart1("3,1,2").ShouldBe("1836");
        }

        [Fact]
        public void Part2Test1()
        {
            day.ExecutePart2("0,3,6").ShouldBe("175594");
        }
    }
}
