using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;

            Queue<string> namesQueue = new Queue<string>();

            while ((name = Console.ReadLine()) != "End")
            {
                if (name == "Paid")
                {
                    while (namesQueue.Count > 0)
                    {
                        Console.WriteLine(namesQueue.Dequeue());
                    }
                }
                else
                {
                    namesQueue.Enqueue(name);
                }
            }

            Console.WriteLine($"{namesQueue.Count} people remaining.");
        }
    }
}
