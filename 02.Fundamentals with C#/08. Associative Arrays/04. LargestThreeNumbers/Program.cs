using System;
using System.Linq;

namespace _04._LargestThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (i >= 3)
                {
                    break;
                }

                Console.Write(array[i] + " ");
            }
        }
    }
}
