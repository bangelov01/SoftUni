using System;

namespace _04._NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int empOneCount = int.Parse(Console.ReadLine());
            int empTwoCount = int.Parse(Console.ReadLine());
            int empThreeCount = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalToAnswer = empOneCount + empTwoCount + empThreeCount;
            int answeredForHour = 0;
            int hours = 0;

            if (peopleCount > 0)
            {
                while (true)
                {
                    if (hours % 4 == 0 && hours > 0)
                    {
                        hours++;
                        continue;
                    }
                    else
                    {
                        answeredForHour += totalToAnswer;
                        hours++;
                    }
                    if (answeredForHour >= peopleCount)
                    {
                        if (hours % 4 == 0)
                        {
                            hours++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
