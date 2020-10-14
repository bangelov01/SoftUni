using System;

namespace _10._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalSteps = 0;
            bool goalReached = false;
            while (input != "Going home")
            {
                int steps = int.Parse(input);
                totalSteps += steps;

                if (totalSteps >= 10000)
                {
                    goalReached = true;
                    break;
                }
                input = Console.ReadLine();
            }

            if (goalReached)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                int stepsToHome = int.Parse(Console.ReadLine());
                totalSteps += stepsToHome;
                if (totalSteps >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
                }
                else
                {
                    Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
                }

            }
        }
    }
}
