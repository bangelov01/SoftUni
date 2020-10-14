using System;

namespace _13.Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            ;
            double priceRocket = double.Parse(Console.ReadLine());
            int amountRockets = int.Parse(Console.ReadLine());
            int amountShoes = int.Parse(Console.ReadLine());

            double priceShoes = priceRocket / 6;
            double priceRockets = priceRocket * amountRockets;
            double allPriceShoes = amountShoes * priceShoes;

            double otherGearPrice = (allPriceShoes + priceRockets) * 0.2;
            double totalPrice =  allPriceShoes + priceRockets + otherGearPrice;

            double playerPrice = totalPrice / 8;
            double sponsorPrice = totalPrice * 7 / 8;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(playerPrice)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(sponsorPrice)}");
        }
    }
}
