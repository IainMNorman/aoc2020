namespace Aoc2020.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day14 : IDay
    {
        public string ExecutePart1(string input)
        {
            var lines = input.ToLines();
            var mask = new string('X', 36);
            var memory = new Dictionary<long, long>();
            foreach (var line in lines)
            {
                if (line.Contains('X'))
                {
                    mask = line.Substring(7);
                }
                else
                {
                    var parts = line.Split("] = ");
                    var memLoc = long.Parse(parts[0].Substring(4));
                    var value = parts[1];
                    var result = this.GetMaskedResult(mask, long.Parse(value));
                    memory[memLoc] = result;
                }
            }

            var ans = memory.Sum(x => x.Value);
            return ans.ToString();
        }

        public long GetMaskedResult(string mask, long value)
        {
            var result = new StringBuilder(new string('.', 36));
            var valueString = this.LongToBinaryString(value);
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'X')
                {
                    result[i] = valueString[i];
                }
                else
                {
                    result[i] = mask[i];
                }
            }

            return this.BinaryStringToLong(result.ToString());
        }

        public string LongToBinaryString(long value)
        {
            return Convert.ToString(value, 2).PadLeft(36, '0');
        }

        public long BinaryStringToLong(string value)
        {
            return Convert.ToInt64(value, 2);
        }

        public List<string> V2MaskToV1Masks(string v2mask)
        {
            var v1masks = new List<string>();
            var xcount = v2mask.Count(x => x == 'X');

            for (int i = 0; i < Math.Pow(2, xcount); i++)
            {
                var binaryString = Convert.ToString(i, 2).PadLeft(xcount, '0');
                var v1mask = new StringBuilder(new string('.', 36));
                var bCount = 0;

                for (int j = 0; j < v2mask.Length; j++)
                {
                    if (v2mask[j] == '0')
                    {
                        v1mask[j] = 'X';
                    }

                    if (v2mask[j] == '1')
                    {
                        v1mask[j] = '1';
                    }

                    if (v2mask[j] == 'X')
                    {
                        v1mask[j] = binaryString[bCount];
                        bCount++;
                    }
                }

                v1masks.Add(v1mask.ToString());
            }

            return v1masks;
        }

        public string ExecutePart2(string input)
        {
            var lines = input.ToLines();
            var masks = new List<string>();
            var memory = new Dictionary<long, long>();
            foreach (var line in lines)
            {
                if (line.Contains('X'))
                {
                    masks = this.V2MaskToV1Masks(line.Substring(7));
                }
                else
                {
                    var parts = line.Split("] = ");
                    var memLoc = long.Parse(parts[0].Substring(4));
                    var value = long.Parse(parts[1]);
                    foreach (var mask in masks)
                    {
                        var result = this.GetMaskedResult(mask, memLoc);
                        memory[result] = value;
                    }
                }
            }

            var ans = memory.Sum(x => x.Value);
            return ans.ToString();
        }
    }
}
