using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (numbers.All(x => x < 0))
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x >= 0).Reverse()));
            }
        }
    }
}
