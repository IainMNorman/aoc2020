using Aoc2020;
using Aoc2020.Day16;

using Shouldly;

using Xunit;

namespace Tests
{
    public class Day16Tests
    {
        private IDay day;

        public Day16Tests()
        {
            day = new Day16();
        }

        [Fact]
        public void Part1Test1()
        {
            var input = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12".Replace("\r", string.Empty);

            day.ExecutePart1(input).ShouldBe("71");
        }        
    }
}
