using Aoc2020.Day4;

using Shouldly;

using System;

using Xunit;

namespace Tests
{
    public class Day4Tests
    {
        Day4 day4;

        public Day4Tests()
        {
            day4 = new Day4();
        }

        [Fact]
        public void Test1False()
        {
            day4.IsValid(@"eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926").ShouldBeFalse();
        }

        [Fact]
        public void Test2False()
        {
            day4.IsValid(@"iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946").ShouldBeFalse();
        }

        [Fact]
        public void Test3False()
        {
            day4.IsValid(@"hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277").ShouldBeFalse();
        }

        [Fact]
        public void Test4False()
        {
            day4.IsValid(@"hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007").ShouldBeFalse();
        }

        [Fact]
        public void Test5False()
        {
            day4.IsValid(@"hgt:58in ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:35564123 byr:2007").ShouldBeFalse();
        }

        [Fact]
        public void Test1True()
        {
            day4.IsValid(@"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f").ShouldBeTrue();
        }

        [Fact]
        public void Test2True()
        {
            day4.IsValid(@"eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm").ShouldBeTrue();
        }

        [Fact]
        public void Test3True()
        {
            day4.IsValid(@"hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022").ShouldBeTrue();
        }

        [Fact]
        public void Test4True()
        {
            day4.IsValid(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719").ShouldBeTrue();
        }
    }
}
