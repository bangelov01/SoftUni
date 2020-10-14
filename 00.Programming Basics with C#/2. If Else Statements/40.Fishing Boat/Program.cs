using System;

namespace _40.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishermen = int.Parse(Console.ReadLine());
            ;
            double priceForSeason = 0;

            switch (season)
            {
                case "Spring":
                    priceForSeason = 3000; break;
                case "Autumn":
                case "Summer":
                    priceForSeason = 4200; break;
                case "Winter":
                    priceForSeason = 2600; break;
            }

            if (numberOfFishermen <= 6)
            {
                priceForSeason *= 0.90;
            }
            else if (numberOfFishermen > 6 && numberOfFishermen <=11)
            {
                priceForSeason *= 0.85;
            }
            else
            {
                priceForSeason *= 0.75;
            }

            if (numberOfFishermen % 2 == 0 && season != "Autumn")
            {
                priceForSeason *= 0.95;
            }

            if (budget >= priceForSeason)
            {
                double leftover = budget - priceForSeason;
                Console.WriteLine($"Yes! You have {leftover:f2} leva left.");
            }
            else
            {
                double needed = priceForSeason - budget;
                Console.WriteLine($"Not enough money! You need {needed:f2} leva.");
            }
        }
    }
}
