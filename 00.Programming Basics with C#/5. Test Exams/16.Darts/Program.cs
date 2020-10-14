using System;

namespace _16.Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            ;
            string playerName = Console.ReadLine();
            string hitBox = Console.ReadLine();
            int startPoints = 301;
            int goodShotCount = 0;
            int badShotCount = 0;
            bool win = false;

            while (hitBox != "Retire")
            {
                int points = int.Parse(Console.ReadLine());
                switch (hitBox)
                {
                    case "Double":
                        points *= 2;
                        if (points > startPoints)
                        {
                            badShotCount++;
                        }
                        else
                        {
                            startPoints -= points;
                            goodShotCount++;
                        }
                        break;
                    case "Triple":
                        points *= 3;
                        if (points > startPoints)
                        {
                            badShotCount++;
                        }
                        else
                        {
                            startPoints -= points;
                            goodShotCount++;
                        }
                        break;
                    default:
                        if (points > startPoints)
                        {
                            badShotCount++;
                        }
                        else
                        {
                            startPoints -= points;
                            goodShotCount++;
                        }
                        break;
                }
                if (startPoints <= 0)
                {
                    win = true;
                    break;
                }

                hitBox = Console.ReadLine();
                points = 0;
            }
            if (win)
            {
                Console.WriteLine($"{playerName} won the leg with {goodShotCount} shots.");
            }
            else
            {
                Console.WriteLine($"{playerName} retired after {badShotCount} unsuccessful shots.");
            }
        }
    }
}
