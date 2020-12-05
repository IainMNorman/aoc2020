namespace Aoc2020.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> list)
        {
            return Enumerable
            .Range(1, (1 << list.Count()) - 1)
            .Select(index => list.Where((item, idx) => ((1 << idx) & index) != 0));
        }
    }
}
