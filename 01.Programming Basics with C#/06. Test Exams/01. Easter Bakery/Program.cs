using System;

namespace _01._Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceFlowerPerKg = double.Parse(Console.ReadLine());
            double flowerKg = double.Parse(Console.ReadLine());
            double sugarKg = double.Parse(Console.ReadLine());
            double packsOfEggs = double.Parse(Console.ReadLine());
            double packsYeast = double.Parse(Console.ReadLine());

            double priceSugarKg = priceFlowerPerKg * 0.75;
            double priceEggsPack = priceFlowerPerKg * 1.1;
            double priceYeastPack = priceSugarKg * 0.2;

            double totalSum = (priceFlowerPerKg * flowerKg) + (priceSugarKg * sugarKg)
                + (priceEggsPack * packsOfEggs) + (priceYeastPack * packsYeast);

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
