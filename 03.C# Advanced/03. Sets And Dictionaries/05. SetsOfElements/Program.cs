using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sizeOne = setSizes[0];
            int sizeTwo = setSizes[1];

            HashSet<int> firstSet = new HashSet<int>(sizeOne);
            HashSet<int> secondSet = new HashSet<int>(sizeTwo);

            int inputCycles = sizeOne + sizeTwo;

            for (int i = 1; i <= inputCycles; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (i <= sizeOne)
                {
                    firstSet.Add(input);
                }
                else
                {
                    secondSet.Add(input);
                }
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
