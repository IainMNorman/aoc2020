using Aoc2020.Day6;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests
{
    public class Day6Tests
    {
        public Day6Tests()
        {
            this.day = new Day6();
        }

        Day6 day;

        [Fact]
        public void P1T1()
        {
            this.day.ExecutePart1(@"abc

a
b
c

ab
ac

a
a
a
a

b".Replace("\r", string.Empty)).ShouldBe("11");
        }
    }
}
