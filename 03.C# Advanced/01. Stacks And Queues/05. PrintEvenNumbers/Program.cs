using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numsQueue = new Queue<int>();

            for (int i = 0; i < integers.Length; i++)
            {
                if (integers[i] % 2 == 0)
                {
                    numsQueue.Enqueue(integers[i]);
                }
            }

            Console.WriteLine(string.Join(", ", numsQueue));
        }
    }
}
