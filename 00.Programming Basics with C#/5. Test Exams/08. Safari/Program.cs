using System;

namespace _08._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double litresFuel = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double fuelPrice = litresFuel * 2.10;
            double priceTotal = fuelPrice + 100;

            switch (day)
            {
                case "Saturday":
                    priceTotal *= 0.90; break;
                case "Sunday":
                    priceTotal *= 0.80; break;
            }

            if (budget >= priceTotal)
            {
                budget -= priceTotal;
                Console.WriteLine($"Safari time! Money left: {budget:f2} lv.");
            }
            else
            {
                priceTotal -= budget;
                Console.WriteLine($"Not enough money! Money needed: {priceTotal:f2} lv.");
            }
        }
    }
}
