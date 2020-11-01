using System;
using System.Data;

namespace _12._ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double sumNoTax = 0;

            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                sumNoTax += price;
                input = Console.ReadLine();
            }

            double tax = sumNoTax * 0.20;

            double totalPrice = sumNoTax + tax;

            if (input == "special")
            {
                double discount = totalPrice * 0.10;
                totalPrice = totalPrice - discount;
            }
            if (totalPrice <= 0)
            {
                Console.WriteLine($"Invalid order!");
                return;
            }

            Console.WriteLine($"Congratulations you've just bought a new computer!\r\n" +
                $"Price without taxes: {sumNoTax:f2}$\r\n" +
                $"Taxes: {tax:f2}$\r\n" +
                $"-----------\r\n" +
                $"Total price: {totalPrice:f2}$");
        }
    }
}
