using System;
using System.Net.Security;

namespace _18._Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string tournamentName = Console.ReadLine();
            double allGameCount = 0;
            double win = 0;
            double lost = 0;

            while (tournamentName != "End of tournaments")
            {
                double matches = double.Parse(Console.ReadLine());
                double gameCount = 0;

                for (int i = 1; i <= matches; i++)
                {
                    allGameCount++;
                    gameCount++;
                    double desiPoints = double.Parse(Console.ReadLine());
                    double opponentPoints = double.Parse(Console.ReadLine());

                    if (desiPoints > opponentPoints)
                    {
                        win++;
                        desiPoints -= opponentPoints;
                        Console.WriteLine($"Game {gameCount} of tournament {tournamentName}: win with {desiPoints} points.");
                    }
                    else
                    {
                        lost++;
                        opponentPoints -= desiPoints;
                        Console.WriteLine($"Game {gameCount} of tournament {tournamentName}: lost with {opponentPoints} points.");
                    }
                }
                tournamentName = Console.ReadLine();
            }
            Console.WriteLine($"{win/allGameCount*100:f2}% matches win");
            Console.WriteLine($"{lost/allGameCount*100:f2}% matches lost");
        }
    }
}
