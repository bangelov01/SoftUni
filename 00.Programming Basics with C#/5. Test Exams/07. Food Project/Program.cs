using System;

namespace _07._Food_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            double chickenMenus = double.Parse(Console.ReadLine());
            double fishMenus = double.Parse(Console.ReadLine());
            double veganMenus = double.Parse(Console.ReadLine());

            double chickenTotal = chickenMenus * 10.35;
            double fishTotal = fishMenus * 12.40;
            double veganTotal = veganMenus * 8.15;

            double totalPrice = chickenTotal + fishTotal + veganTotal;
            double percent = totalPrice * 0.20;
            double total = totalPrice + percent + 2.50;

            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
