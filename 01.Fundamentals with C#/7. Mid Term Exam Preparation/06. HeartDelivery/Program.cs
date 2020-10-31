using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _06._HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine().Split("@").Select(int.Parse).ToList();

            string command = string.Empty;
            int jumpIndex = 0;

            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] commandArr = command.Split(" ");

                int jumpDistance = int.Parse(commandArr[1]);

                jumpIndex += jumpDistance;

                if (jumpIndex > neighborhood.Count - 1)
                {
                    jumpIndex = 0;
                }

                if (neighborhood[jumpIndex] == 0)
                {
                    Console.WriteLine($"Place {jumpIndex} already had Valentine's day.");
                }
                else if ((neighborhood[jumpIndex] - 2) == 0)
                {
                    neighborhood[jumpIndex] -= 2;
                    Console.WriteLine($"Place {jumpIndex} has Valentine's day.");
                }
                else
                {
                    neighborhood[jumpIndex] -= 2;
                }
            }

            Console.WriteLine($"Cupid's last position was {jumpIndex}.");

            if (neighborhood.Any(x => x != 0))
            {
                int failCount = neighborhood.Where(x => x > 0).Count();
                Console.WriteLine($"Cupid has failed {failCount} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
