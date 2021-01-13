using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            int passes = int.Parse(Console.ReadLine());
            int countPasses = 0;

            Queue<string> kidsQueue = new Queue<string>(kids);

            while (kidsQueue.Count > 1)
            {
                countPasses++;
                if (countPasses == passes)
                {
                    Console.WriteLine($"Removed {kidsQueue.Dequeue()}");
                    countPasses = 0;
                }
                else
                {
                    string kid = kidsQueue.Dequeue();
                    kidsQueue.Enqueue(kid);
                }
            }

            Console.WriteLine($"Last is {kidsQueue.Dequeue()}");
        }
    }
}
