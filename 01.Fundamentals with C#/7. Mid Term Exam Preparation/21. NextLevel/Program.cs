using System;

namespace _21._NextLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            double xpNeededForTank = double.Parse(Console.ReadLine());
            int countOfBattles = int.Parse(Console.ReadLine());

            double sumXp = 0;
            int battleCount = 0;

            while (sumXp < xpNeededForTank && battleCount < countOfBattles)
            {
                double xpRecieved = double.Parse(Console.ReadLine());
                sumXp += xpRecieved;
                battleCount++;
                if (battleCount % 3 == 0)
                {
                    double xpBoost = xpRecieved * 0.15;
                    sumXp += xpBoost;
                }
                if (battleCount % 5 == 0)
                {
                    double xpLoss = xpRecieved * 0.10;
                    sumXp -= xpLoss;
                }
                if (battleCount % 15 == 0)
                {
                    double xpGain = xpRecieved * 0.05;
                    sumXp += xpGain;
                }
            }
            if (sumXp >= xpNeededForTank && battleCount <= countOfBattles)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCount} battles.");
            }
            else
            {
                double neded = xpNeededForTank - sumXp;
                Console.WriteLine($"Player was not able to collect the needed experience, {neded:f2} more needed.");
            }
        }
    }
}
