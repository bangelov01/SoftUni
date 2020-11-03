using System;

namespace _14._DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = int.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double money = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 4 == 0)
                {
                    double bonusPer = money * 0.25;
                    money += bonusPer;
                }
                if (i % 2 != 0 && i != 1)
                {
                    double spendPer = money * 0.16;
                    money -= spendPer;
                }

                double savePer = journeyCost * 0.25;
                money += savePer;
            }

            if (money >= journeyCost)
            {
                double saved = money - journeyCost;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {saved:f2}lv. for souvenirs.");
            }
            else
            {
                double needed = journeyCost - money;
                Console.WriteLine($"Sorry. You need {needed:f2}lv. more.");
            }
        }
    }
}
