using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            Console.WriteLine($"{string.Join(" ", ReturnAdjecentEqualNumbersSum(numbers))}");
        }

        static List<double> ReturnAdjecentEqualNumbersSum (List<double> numbers)
        {
            List<double> result = new List<double>();
            result.AddRange(numbers);

            for (int i = 0; i < result.Count - 1; i++)
            {
                if (result[i] == result[i + 1])
                {
                    result[i] += result[i + 1];
                    result.RemoveAt(i + 1);
                    i = -1;
                }
            }

            return result;
        }
    }
}
