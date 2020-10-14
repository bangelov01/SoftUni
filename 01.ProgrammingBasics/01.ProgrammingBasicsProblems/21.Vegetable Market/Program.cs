using System;

namespace _21.Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegeKgPrice = double.Parse(Console.ReadLine());
            double fruitKgPrice = double.Parse(Console.ReadLine());
            int vegeKg = int.Parse(Console.ReadLine());
            int fruitKg = int.Parse(Console.ReadLine());

            double euro = 1.94;

            double vegetables = vegeKgPrice * vegeKg;
            double fruits = fruitKgPrice * fruitKg;
            double allTotal = vegetables + fruits;

            double inEuro = allTotal/euro;

            Console.WriteLine($"{inEuro:f2}");
        }
    }
}
