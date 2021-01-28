using System;
using System.Linq;

namespace _01._SortEvennumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sortedNums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .Where(x => x % 2 == 0)
                 .OrderBy(x => x)
                 .ToArray();

            Console.WriteLine(string.Join(", ", sortedNums));
        }
    }
}
