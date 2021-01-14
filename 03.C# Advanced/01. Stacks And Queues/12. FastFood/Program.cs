using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orderQueue = new Queue<int>(orders);

            int biggestOrder = orderQueue.Max();
            Console.WriteLine(biggestOrder);
            bool isEmpty = false;

            while (orderQueue.Count > 0)
            {
                int orderCheck = orderQueue.Peek();

                if (orderCheck <= foodQuantity)
                {
                    orderQueue.Dequeue();
                    foodQuantity -= orderCheck;
                }
                else
                {
                    isEmpty = true;
                    break;
                }
            }

            if (isEmpty)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orderQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
