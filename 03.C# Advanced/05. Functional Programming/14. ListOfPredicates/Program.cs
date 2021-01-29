using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endRange = int.Parse(Console.ReadLine());

            List<int> dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers = Enumerable.Range(1, endRange).ToList();

            foreach (var num in numbers)
            {
                if (dividers.All(d => num % d == 0))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
