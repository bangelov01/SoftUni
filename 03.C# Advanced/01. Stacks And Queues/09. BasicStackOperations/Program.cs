using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numsToOperateOn = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int elementsToPush = numsToOperateOn[0];
            int elementsToPop = numsToOperateOn[1];
            int elementToLookFor = numsToOperateOn[2];

            Stack<int> intStack = new Stack<int>(integers);

            int popped = 0;

            while (popped < elementsToPop)
            {
                intStack.Pop();
                popped++;
            }

            if (intStack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
                return;
            }

            if (intStack.Count > 0)
            {
                Console.WriteLine(intStack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
