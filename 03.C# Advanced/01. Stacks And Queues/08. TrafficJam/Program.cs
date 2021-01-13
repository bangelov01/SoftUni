using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCarsToPass = int.Parse(Console.ReadLine());
            int totalCarsCount = 0;

            Queue<string> carsInQueue = new Queue<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command != "green")
                {
                    carsInQueue.Enqueue(command);
                }
                else
                {
                    int carsCount = 0;
                    while (carsInQueue.Count > 0 && carsCount != numOfCarsToPass)
                    {
                        Console.WriteLine($"{carsInQueue.Dequeue()} passed!");
                        carsCount++;
                        totalCarsCount++;
                    }
                }
            }
            Console.WriteLine($"{totalCarsCount} cars passed the crossroads.");
        }
    }
}
