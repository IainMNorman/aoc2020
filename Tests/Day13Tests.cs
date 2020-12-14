using Aoc2020.Day13;

using Shouldly;

using Xunit;

namespace Tests
{
    public class Day13Tests
    {
        Day13 Day;

        public Day13Tests()
        {
            this.Day = new Day13();
        }

        [Fact]
        public void Part1Test1()
        {
            this.Day.ExecutePart1(@"939
7,13,x,x,59,x,31,19").ShouldBe("295");
        }

        [Fact]
        public void Part2Test1()
        {
            this.Day.ExecutePart2(@"939
67,7,59,61").ShouldBe("754018");
        }

        [Fact]
        public void Part2Test2()
        {
            this.Day.ExecutePart2(@"939
67,x,7,59,61").ShouldBe("779210");
        }

        [Fact]
        public void Part2Test3()
        {
            this.Day.ExecutePart2(@"939
67,7,x,59,61").ShouldBe("1261476");
        }

        [Fact]
        public void Part2Test4()
        {
            this.Day.ExecutePart2(@"939
1789,37,47,1889").ShouldBe("1202161486");
        }

        [Fact]
        public void Part2Test5()
        {
            this.Day.ExecutePart2(@"939
17,x,13,19").ShouldBe("3417");
        }
    }
}
