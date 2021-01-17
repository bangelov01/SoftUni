using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<char> carChars = new Queue<char>();

            string input = string.Empty;

            Queue<string> carsQueue = new Queue<string>();

            int totalCarsPassed = 0;
            bool isHit = false;
            string carHit = string.Empty;
            char charHit = ' ';

            while ((input = Console.ReadLine()) != "END")
            {
                if (!isHit)
                {
                    if (input == "green")
                    {
                        if (carsQueue.Count == 0)
                        {
                            continue;
                        }
                        else
                        {
                            int greenDurationToUse = greenDuration;
                            int freeDurationToUse = freeWindowDuration;

                            while (carsQueue.Count > 0 && greenDurationToUse > 0)
                            {
                                string car = carsQueue.Peek();

                                if (car.Length <= greenDurationToUse)
                                {
                                    greenDurationToUse -= car.Length;
                                    totalCarsPassed++;
                                    carsQueue.Dequeue();
                                    continue;
                                }
                                else
                                {
                                    int remainingLength = car.Length - greenDurationToUse;

                                    if (remainingLength <= freeDurationToUse)
                                    {

                                        totalCarsPassed++;
                                        greenDurationToUse -= car.Length - remainingLength;
                                        carsQueue.Dequeue();
                                        continue;
                                    }
                                    else
                                    {
                                        int leftLength = car.Length - greenDurationToUse - freeDurationToUse;
                                        carHit = car;
                                        isHit = true;
                                        int indexHit = car.Length - leftLength;
                                        charHit = car[indexHit];
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        carsQueue.Enqueue(input);
                    }
                }
            }
            if (isHit)
            {
                Console.WriteLine($"A crash happened!\r\n{carHit} was hit at {charHit}.");
            }
            else
            {
                Console.WriteLine($"Everyone is safe.\r\n{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
}
