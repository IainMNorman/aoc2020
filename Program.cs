namespace Aoc2020
{
    using System;
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

            try
            {
                var input = await http.GetStringAsync($"https://aocproxy.azurewebsites.net/2020/day/{argDay}/input");
                day.ExecutePart1(input);
                day.ExecutePart2(input);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error fetching Day{argDay} input!");
                return;
            }
        }
    }
}
