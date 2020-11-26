using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            Console.WriteLine(string.Join(" ", ReturnGaussTrick(numbers)));
        }

        static List<int> ReturnGaussTrick(List<int> numbers)
        {
            List<int> result = new List<int>();
            result.AddRange(numbers);

            int originalLength = result.Count;

            for (int i = 0; i < originalLength / 2; i++)
            {
                result[i] += result[result.Count - 1];
                result.RemoveAt(result.Count - 1);
            }
            return result;
        }
    }
}
