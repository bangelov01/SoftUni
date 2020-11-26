using System;

namespace _08._Smart_Lili
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMashinePrice = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            
            double money = 0;
            double savings = 0;
            double toyCount = 0;
            for (int i = 1; i <= age ; i++)
            {
                if (i % 2 == 0)
                {
                    money += 10;

                    savings += money;
                    savings -= 1;
                }
                else
                {
                    toyCount++;
                }

            }
            toyCount *= toysPrice;
            double savedMoney = savings + toyCount;

            if (savedMoney >= washingMashinePrice)
            {
                savedMoney -= washingMashinePrice;
                Console.WriteLine($"Yes! {savedMoney:f2}");
            }
            else
            {
                washingMashinePrice -= savedMoney;
                Console.WriteLine($"No! {washingMashinePrice:f2}");
            }

        }
    }
}
