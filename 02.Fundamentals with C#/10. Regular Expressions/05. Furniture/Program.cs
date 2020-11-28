using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _05._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            string regex = @">>([A-z]+)<<(\d+\.?\d+)!(\d+)";

            List<string> savedItems = new List<string>();

            double sum = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match item = Regex.Match(input, regex);

                if (item.Success)
                {
                    string product = item.Groups[1].Value;
                    savedItems.Add(product);
                    double price = double.Parse(item.Groups[2].Value);
                    int quantity = int.Parse(item.Groups[3].Value);
                    sum += quantity * price;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in savedItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
