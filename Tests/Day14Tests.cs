using Aoc2020;
using Aoc2020.Day14;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests
{
    public class Day14Tests
    {
        private Day14 day;

        public Day14Tests()
        {
            this.day = new Day14();
        }

        [Fact]
        public void MaskTest1()
        {
            day.GetMaskedResult("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 11)
                .ShouldBe(73);
        }

        [Fact]
        public void MaskTest2()
        {
            day.GetMaskedResult("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 101)
                .ShouldBe(101);
        }

        [Fact]
        public void MaskTest3()
        {
            day.GetMaskedResult("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", 0)
                .ShouldBe(64);
        }
    }
}
