using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _07._SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string pattern = @"\%(?<name>[A-Z][a-z]+)\%([^\|\$\%\.]+)?\<(?<product>\w+)\>([^\|\$\%\.]+)?\|(?<quantity>\d+)\|([^\d\|\$\%\.]+)?(?<price>\d+\.?\d+)\$";

            double totalIncome = 0.00;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double totalPrice = quantity * price;

                    totalIncome += totalPrice;

                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
