using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            string[] pumpInfo = new string[numberOfPumps];
            int[] pumpIndexes = new int[numberOfPumps];

            for (int i = 0; i < numberOfPumps; i++)
            {
                string input = Console.ReadLine();
                pumpInfo[i] = input;
                pumpIndexes[i] = i;

            }

            Queue<int> pumpQueue = new Queue<int>(pumpIndexes);

            bool madeCircle = false;

            for (int i = 0; i < numberOfPumps; i++)
            {
                int startIndex = pumpIndexes[i];
                int tank = 0;
                int currentStart = 0;

                while (startIndex != pumpQueue.Peek())
                {
                    int toEnqueue = pumpQueue.Dequeue();
                    pumpQueue.Enqueue(toEnqueue);
                }

                while (true)
                {
                    string[] info = pumpInfo[pumpQueue.Peek()].Split();
                    int petrolAmount = int.Parse(info[0]);
                    int distanceAmount = int.Parse(info[1]);
                    tank += petrolAmount;

                    if (distanceAmount <= tank)
                    {
                        tank -= distanceAmount;
                        currentStart = pumpQueue.Dequeue();
                        pumpQueue.Enqueue(currentStart);
                        if (startIndex == pumpQueue.Peek())
                        {
                            madeCircle = true;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (madeCircle)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
