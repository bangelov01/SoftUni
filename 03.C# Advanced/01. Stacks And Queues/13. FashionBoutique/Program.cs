
using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCounter = 1;

            Stack<int> clothesStack = new Stack<int>(clothes);

            int sum = 0;

            while (clothesStack.Count > 0)
            {
                sum += clothesStack.Peek();
                if (sum <= rackCapacity)
                {
                    clothesStack.Pop();
                }
                else
                {
                    rackCounter++;
                    sum = 0;
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}
