using System;
using System.Globalization;

namespace _01.Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string amount = Console.ReadLine();
            double sum = 0;

            while (amount != "Start")
            {
                double doubleAmount = Convert.ToDouble(amount);
                if (doubleAmount == 0.1 || doubleAmount == 0.2 || doubleAmount == 0.5 || doubleAmount == 1
                    || doubleAmount == 2)
                {
                    sum += doubleAmount;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {doubleAmount}");
                }

                amount = Console.ReadLine();
            }

            string product = Console.ReadLine();
            double price = 0;

            while (product != "End")
            {
                switch (product)
                {
                    case "Nuts": 
                        price = 2.0;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                if (price > sum)
                {
                    Console.WriteLine($"Sorry, not enough money");
                }
                else
                {
                    sum -= price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }

                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}
