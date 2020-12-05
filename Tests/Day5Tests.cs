using Aoc2020.Day5;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests
{
    public class Day5Tests
    {
        public Day5Tests()
        {
            this.day = new Day5();
        }

        Day5 day;

        [Fact]
        public void P1_1()
        {
            day.PassToSeatId("BFFFBBFRRR").ShouldBe(567);
        }

        [Fact]
        public void P1_2()
        {
            day.PassToSeatId("FFFBBBFRRR").ShouldBe(119);
        }

        [Fact]
        public void P1_3()
        {
            day.PassToSeatId("BBFFBBFRLL").ShouldBe(820);
        }


    }
}
