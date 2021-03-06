﻿namespace Aoc2020.Day4
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day4 : IDay
    {
        public string ExecutePart1(string input)
        {
            var lines = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

            return lines.Count(x =>
            x.Contains("byr") &&
            x.Contains("iyr") &&
            x.Contains("eyr") &&
            x.Contains("hgt") &&
            x.Contains("hcl") &&
            x.Contains("ecl") &&
            x.Contains("pid")).ToString();
        }

        public string ExecutePart2(string input)
        {
            var test = this.IsValid(@"iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719");

            var lines = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

            var validCount = 0;

            foreach (var line in lines)
            {
                if (this.IsValid(line))
                {
                    validCount++;
                }
            }

            return validCount.ToString();
        }

        public bool IsValid(string line)
        {
            var valid = true;
            try
            {
                var byr = int.Parse(Regex.Match(line, @"byr:(\d{4})").Groups[1].Value);
                var iyr = int.Parse(Regex.Match(line, @"iyr:(\d{4})").Groups[1].Value);
                var eyr = int.Parse(Regex.Match(line, @"eyr:(\d{4})").Groups[1].Value);
                var hgt = int.Parse(Regex.Match(line, @"hgt:(\d*)(cm|in)").Groups[1].Value);
                var hgtUnit = Regex.Match(line, @"hgt:(\d*)(cm|in)").Groups[2].Value;
                var hcl = Regex.Match(line, @"hcl:(#[0-9a-f]{6})").Groups[1].Value;
                var ecl = Regex.Match(line, @"ecl:(...)").Groups[1].Value;
                var pid = Regex.Match(line, @"pid:(\d{9})(\s|$)").Groups[1].Value;

                if (byr < 1920 || byr > 2002)
                {
                    valid = false;
                }

                if (iyr < 2010 || iyr > 2020)
                {
                    valid = false;
                }

                if (eyr < 2020 || eyr > 2030)
                {
                    valid = false;
                }

                switch (hgtUnit)
                {
                    case "cm":
                        if (hgt < 150 || hgt > 193)
                        {
                            valid = false;
                        }

                        break;
                    case "in":
                        if (hgt < 59 || hgt > 76)
                        {
                            valid = false;
                        }

                        break;
                }

                if (!(
                    ecl == "amb" ||
                    ecl == "blu" ||
                    ecl == "brn" ||
                    ecl == "gry" ||
                    ecl == "grn" ||
                    ecl == "hzl" ||
                    ecl == "oth"))
                {
                    valid = false;
                }

                if (hcl.Length != 7)
                {
                    valid = false;
                }

                if (pid.Length != 9)
                {
                    valid = false;
                }
            }
            catch (Exception)
            {
                valid = false;
            }

            return valid;
        }
    }
}
