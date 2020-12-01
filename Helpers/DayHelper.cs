namespace Aoc2020
{
    using System;
    using System.Linq;

    public class DayHelper
    {
        public static Type[] GetAllDays()
        {
            return
                typeof(DayHelper).Assembly.GetExportedTypes()
                    .Where(x => typeof(IDay).IsAssignableFrom(x) && !x.IsAbstract)
                    .ToArray();
        }

        public static Type GetDay(string name)
        {
            return GetAllDays().FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
