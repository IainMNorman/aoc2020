namespace Aoc2020.Day1
{
    using System;
    using System.Linq;

    public class Day1 : IDay
    {
        public void ExecutePart1(string input)
        {
            var lines = input.ToIntArray();
            void Loop()
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        if (lines[i] + lines[j] == 2020)
                        {
                            Console.WriteLine("Answer Day 1 Part 2:" + (lines[i] * lines[j]));
                            return;
                        }
                    }
                }
            }

            Loop();
        }

        public void ExecutePart2(string input)
        {
            var lines = input.ToIntArray();
            void Loop()
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines.Length; j++)
                    {
                        for (int k = 0; k < lines.Length; k++)
                        {
                            if (lines[i] + lines[j] + lines[k] == 2020)
                            {
                                Console.WriteLine("Answer Day 1 Part 2:" + (lines[i] * lines[j] * lines[k]));
                                return;
                            }
                        }
                    }
                }
            }

            Loop();
        }
    }
}
