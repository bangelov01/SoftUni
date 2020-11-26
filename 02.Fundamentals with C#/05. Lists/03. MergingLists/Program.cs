using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbersSecond = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            ReturnMergedList(numbers, numbersSecond);

            Console.WriteLine(string.Join(" ", ReturnMergedList(numbers, numbersSecond)));

        }

        static List<int> ReturnMergedList(List<int> numbers, List<int> numbersSecond)
        {
            List<int> result = new List<int>();

            int maxCount = 0;
            if (numbers.Count > numbersSecond.Count)
            {
                maxCount = numbers.Count;
            }
            else
            {
                maxCount = numbersSecond.Count;
            }

            for (int i = 0; i < maxCount; i++)
            {
                if (numbers.Count > i)
                {
                    result.Add(numbers[i]);
                }
                if (numbersSecond.Count > i)
                {
                    result.Add(numbersSecond[i]);
                }
            }
            return result;
        }
    }
}
