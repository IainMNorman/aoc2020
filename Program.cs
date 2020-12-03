namespace Aoc2020
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;

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
            Console.WriteLine("Day " + argDay);
            Console.WriteLine("Starting part 1");
            stopwatch.Start();
            var p1 = day.ExecutePart1(input);
            stopwatch.Stop();
            Console.WriteLine("Part 1 answer: " + p1);
            totalMs += stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Part 1 took : {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine("Starting part 2");
            stopwatch.Reset();
            stopwatch.Start();
            var p2 = day.ExecutePart2(input);
            stopwatch.Stop();
            Console.WriteLine("Part 2 answer: " + p2);
            Console.WriteLine($"Part 2 took : {stopwatch.ElapsedMilliseconds}ms");
            totalMs += stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Day {argDay} took {totalMs}ms ({stopwatch.ElapsedTicks} ticks)");
        }
    }
}
