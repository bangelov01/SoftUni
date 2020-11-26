using System;

namespace _17._EasterBread
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceOneKgFlour = double.Parse(Console.ReadLine());

            double eggsPackPrice = priceOneKgFlour * 0.75;
            double milk250MlPrice = (priceOneKgFlour + (priceOneKgFlour * 0.25))/4;

            double totalPrice = eggsPackPrice + priceOneKgFlour + milk250MlPrice;

            int eggs = 0;
            int breadCount = 0;
            while (budget > totalPrice)
            {
                eggs += 3;
                breadCount++;
                if (breadCount % 3 == 0)
                {
                    int eggsToRemove = breadCount - 2;
                    eggs -= eggsToRemove;
                }
                budget -= totalPrice;
            }

            Console.WriteLine($"You made {breadCount} cozonacs! Now you have {eggs} eggs and {budget:f2}BGN left.");
        }
    }
}
