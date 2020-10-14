using System;

namespace _22.Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMagnolias = int.Parse(Console.ReadLine());
            int numberZiumbiul = int.Parse(Console.ReadLine());
            int numberRoses = int.Parse(Console.ReadLine());
            int numberCactuses = int.Parse(Console.ReadLine());
            double priceOfGift = double.Parse(Console.ReadLine());
            
            double sumOfFlowers = (numberMagnolias * 3.25) + (numberZiumbiul * 4) + (numberRoses * 3.50)
                + (numberCactuses * 8);
            double afterTaxPay = sumOfFlowers * 0.95;

            if (afterTaxPay >= priceOfGift)
            {
                afterTaxPay -= priceOfGift;

                Console.WriteLine($"She is left with {Math.Floor(afterTaxPay)} leva.");
            }
            else
            {
                priceOfGift -= afterTaxPay;

                Console.WriteLine($"She will have to borrow {Math.Ceiling(priceOfGift)} leva.");
            }
        }
    }
}
