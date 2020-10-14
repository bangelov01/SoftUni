using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{TotalPriceCalc(Console.ReadLine(), int.Parse(Console.ReadLine())):f2}");
        }

        static double TotalPriceCalc (string name, int quantity)
        {
            switch (name)
            {
                case "coffee":
                    return 1.50 * quantity;
                case "water":
                    return 1.00 * quantity;
                case "coke":
                    return 1.40 * quantity;
                case "snacks":
                    return 2.00 * quantity;
                default:
                    return 0;
            }
        }
    }
}
