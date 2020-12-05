namespace Aoc2020
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Aoc2020.Helpers;

    public class Program
    {
        private static void Main(string[] args)
        {
            AsyncMain(args[0]).GetAwaiter().GetResult();
        }

        private static async Task AsyncMain(string argDay)
        {
            var dayType = DayHelper.GetDay($"Day{argDay}");

            if (dayType == null)
            {
                Console.WriteLine($"Day{argDay} does not exist!");
                return;
            }

            var day = (IDay)Activator.CreateInstance(dayType);
            using var http = new HttpClient();

            string input;

            try
            {
                input = await http.GetStringAsync($"https://aocproxy.azurewebsites.net/2020/day/{argDay}/input");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return;
            }

            var stopwatch = new Stopwatch();
            var totalMs = 0L;
            Console.WriteLine($"Day {argDay}\n");
            stopwatch.Start();
            var p1 = day.ExecutePart1(input);
            stopwatch.Stop();
            Console.WriteLine("Part 1 answer: " + p1);
            totalMs += stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Run time : {stopwatch.ElapsedMilliseconds}ms\n");
            stopwatch.Reset();
            stopwatch.Start();
            var p2 = day.ExecutePart2(input);
            stopwatch.Stop();
            Console.WriteLine("Part 2 answer: " + p2);
            Console.WriteLine($"Run time: {stopwatch.ElapsedMilliseconds}ms\n");
            totalMs += stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Day {argDay} took {totalMs}ms ({stopwatch.ElapsedTicks} ticks)");
        }
    }
}
