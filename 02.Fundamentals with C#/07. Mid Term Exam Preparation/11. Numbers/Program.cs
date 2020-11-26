using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            double average = Math.Round(integers.Average(), 2);

            List<int> biggerThanAvg = integers.Where(x => x > average).ToList();

            if (biggerThanAvg.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            biggerThanAvg.Sort();
            biggerThanAvg.Reverse();

            if (biggerThanAvg.Count > 4)
            {
                int range = biggerThanAvg.Count - 5;
                biggerThanAvg.RemoveRange(5, range);
            }

            Console.WriteLine(string.Join(" ", biggerThanAvg));
        }
    }
}
