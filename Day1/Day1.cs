namespace Aoc2020.Day1
{
    using System;
    using System.Linq;

    public class Day1 : IDay
    {
        public string ExecutePart1(string input)
        {
            var lines = input.ToIntArray();
            string Loop()
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        if (lines[i] + lines[j] == 2020)
                        {
                            return $"{lines[i] * lines[j]}";
                        }
                    }
                }

                return "no answer found";
            }

            return Loop();
        }

        public string ExecutePart2(string input)
        {
            var lines = input.ToIntArray();
            string Loop()
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        for (int k = 0; k < lines.Length; k++)
                        {
                            if (lines[i] + lines[j] + lines[k] == 2020)
                            {
                                return $"{lines[i] * lines[j] * lines[k]}";
                            }
                        }
                    }
                }

                return "no answer found";
            }

            return Loop();
        }
    }
}
