using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Find_Evens_Or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int startNum = boundaries[0];
            int endNum = boundaries[1];

            string command = Console.ReadLine();

            int evenOrOddDiv = 0;

            if (command == "odd")
            {
                evenOrOddDiv = 1;

            }

            List<int> numbers = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            List<int> filtered = ToFilter(numbers, num => num % 2 == evenOrOddDiv || num % 2 == -1);

            Console.WriteLine(string.Join(" ",filtered));
        }

        static List<int> ToFilter(List<int> numbers, Predicate<int> division)
        {
            List<int> finalResult = new List<int>();

            for (int i = 0; i < numbers.Count; 
                i++)
            {
                if (division(numbers[i]))
                {
                    finalResult.Add(numbers[i]);
                }
            }

            return finalResult;
        }
    }
}
