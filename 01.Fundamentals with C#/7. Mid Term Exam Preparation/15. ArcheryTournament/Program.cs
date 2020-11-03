using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.ArcheryTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split("|").Select(int.Parse).ToList();

            string command = string.Empty;

            int finishPoints = 0;

            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] commandArr = command.Split("@");

                string shootTo = commandArr[0];


                if (shootTo == "Shoot Right")
                {
                    int indicteRight = 1;
                     finishPoints += ReturnManipulatedTargets(targets, commandArr, finishPoints, indicteRight);
                }
                else if (shootTo == "Shoot Left")
                {
                    int indicateLeft = 0;
                    finishPoints += ReturnManipulatedTargets(targets, commandArr, finishPoints, indicateLeft);

                }
                else if (shootTo == "Reverse")
                {
                    targets.Reverse();
                }
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {finishPoints} points!");
        }

        static int ReturnManipulatedTargets(List<int> targets, string[] commandArr, int finishPoints, int indicate)
        {
            int startIndex = int.Parse(commandArr[1]);
            int length = int.Parse(commandArr[2]);
            finishPoints = 0;

            if (startIndex > targets.Count - 1 || startIndex < 0)
            {
                return 0;
            }

            while (length != 0)
            {
                if (indicate == 1)
                {
                    if (startIndex < targets.Count - 1)
                    {
                        startIndex++;
                        length--;
                    }
                    else if (startIndex == targets.Count - 1)
                    {
                        startIndex = 0;
                        length--;
                    }
                }
                else if (indicate == 0)
                {
                    if (startIndex > 0)
                    {
                        startIndex--;
                        length--;
                    }
                    else if (startIndex == 0)
                    {
                        startIndex = targets.Count - 1;
                        length--;
                    }
                }

            }

            if (targets[startIndex] >= 5)
            {
                targets[startIndex] -= 5;
                finishPoints += 5;
                return finishPoints;
            }
            else
            {
                finishPoints += targets[startIndex];
                targets[startIndex] = 0;
                return finishPoints;
            }
        }
    }
}
