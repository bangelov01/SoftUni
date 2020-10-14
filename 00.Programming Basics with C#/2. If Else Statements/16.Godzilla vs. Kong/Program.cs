using System;

namespace _16.Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statists = int.Parse(Console.ReadLine());
            double priceForOutfitOneStatist = double.Parse(Console.ReadLine());

            double priceDecor = budget * 0.10;
            double priceForOutfits = statists * priceForOutfitOneStatist;
            
            if (statists > 150)
            {
                priceForOutfits *= 0.90;

            }
                       
                double wholePrice = priceDecor + priceForOutfits;
                if (wholePrice > budget)
                {
                    budget -= wholePrice;

                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {budget*-1:f2} leva more.");
                }
                else if (wholePrice <= budget)
                {
                    budget -= wholePrice;
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {budget:f2} leva left.");
                }
            
        }
    }
}
