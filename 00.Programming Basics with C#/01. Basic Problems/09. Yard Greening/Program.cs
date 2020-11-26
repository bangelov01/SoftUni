using System;

namespace _09._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareMeter = double.Parse(Console.ReadLine());
            double price = squareMeter * 7.61;
            double discount = 0.18 * price;
            double finalprice = price - discount;

            Console.WriteLine($"The final price is: {finalprice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
