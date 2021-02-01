using System;

namespace _10._Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int productCounter = 0;
            bool enoughMoney = true;
            double sumPrice = 0;
            string command = "";
            while ((command = Console.ReadLine()) != "Stop")
            {
                double priceProduct = double.Parse(Console.ReadLine());
                productCounter++;
                if (productCounter % 3 == 0)
                {
                    priceProduct /= 2;
                }
                if (budget >= priceProduct)
                {
                    budget -= priceProduct;
                    sumPrice += priceProduct;
                }
                else
                {
                    double moneyNeeded = priceProduct - budget;
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {moneyNeeded:f2} leva!");
                    enoughMoney = false;
                    break;
                }
            }
            if (enoughMoney)
            {
                Console.WriteLine($"You bought {productCounter} products for {sumPrice:f2} leva.");
            }
        }
    }
}
