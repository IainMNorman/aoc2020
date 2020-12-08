using Aoc2020;
using Aoc2020.Day8;
using Aoc2020.OpCodeComp;

using Shouldly;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Tests
{
    public class Day8Tests
    {
        public Day8Tests()
        {
            this.day = new Day8();
        }

        Day8 day;

        [Fact]
        public void Part_1_example()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6".Replace("\r", string.Empty);

            this.day.ExecutePart1(input).ShouldBe("5");
        }


        [Fact]
        public void Part_2_example()
        {
            var input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6".Replace("\r", string.Empty);

            this.day.ExecutePart2(input).ShouldBe("8");

        }
    }
}
