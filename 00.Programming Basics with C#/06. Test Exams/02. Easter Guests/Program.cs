using System;

namespace _02._Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberGuests = int.Parse(Console.ReadLine());
            double budget = int.Parse(Console.ReadLine());

            double neededBread = Math.Ceiling(numberGuests / 3);
            double neededEggs = numberGuests * 2;
            double priceBread = neededBread * 4;
            double priceEggs = neededEggs * 0.45;
            double totalPrice = priceBread + priceEggs;

            if (totalPrice <= budget)
            {
                budget -= totalPrice;
                Console.WriteLine($"Lyubo bought {neededBread} Easter bread and {neededEggs} eggs.\r\nHe has {budget:f2} lv. left.");
            }
            else 
            {
                totalPrice -= budget;
                Console.WriteLine($"Lyubo doesn't have enough money.\r\nHe needs {totalPrice:f2} lv. more.");

            }

        }
    }
}
