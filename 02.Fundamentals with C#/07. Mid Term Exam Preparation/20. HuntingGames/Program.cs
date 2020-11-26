using System;

namespace _20._HuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double waterAdventure = waterPerDay * days * playersCount;
            double foodAdventure = foodPerDay * days * playersCount;

            int daysCount = 0;

            while (daysCount != days)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;
                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {foodAdventure:f2} food and {waterAdventure:f2} water.");
                    return;
                }
                daysCount++;
                if (daysCount % 2 == 0)
                {
                    double energyBoost = groupEnergy * 0.05;
                    double waterDecrease = waterAdventure * 0.30;
                    groupEnergy += energyBoost;
                    waterAdventure -= waterDecrease;
                }
                if (daysCount % 3 == 0)
                {
                    double foodReduce = foodAdventure / playersCount;
                    double ebergyBoost = groupEnergy * 0.10;
                    groupEnergy += ebergyBoost;
                    foodAdventure -= foodReduce;
                }
            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
        }
    }
}
