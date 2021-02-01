using System;

namespace _16.Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasWeight = double.Parse(Console.ReadLine());
            double orangesWeight = double.Parse(Console.ReadLine());
            double raspberriesWeight = double.Parse(Console.ReadLine());
            double strawberriesWeight = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberriesPrice / 2;
            double orangesPrice = raspberryPrice - (raspberryPrice * 0.40);
            double bananasPrice = raspberryPrice - (raspberryPrice * 0.80);

            double raspberriesSum = raspberriesWeight * raspberryPrice;
            double orangesSum = orangesWeight * orangesPrice;
            double bananasSum = bananasWeight * bananasPrice;
            double strawberriesSum = strawberriesWeight * strawberriesPrice;

            double totalSum = raspberriesSum + orangesSum + bananasSum + strawberriesSum;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
