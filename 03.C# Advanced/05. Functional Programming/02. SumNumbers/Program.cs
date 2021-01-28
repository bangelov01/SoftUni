using System;
using System.Linq;

namespace _02._SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = text => int.Parse(text);

            int[] numbers = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
