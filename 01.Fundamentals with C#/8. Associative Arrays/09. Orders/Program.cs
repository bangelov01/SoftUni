using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<double>> orders = new Dictionary<string, List<double>>();

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArr = input.Split(" ");

                string product = inputArr[0];
                double price = double.Parse(inputArr[1]);
                double quantity = double.Parse(inputArr[2]);

                if (!orders.ContainsKey(product))
                {
                    orders.Add(product, new List<double> {price, quantity});
                }
                else
                {
                    if (orders[product][0] != price)
                    {
                        orders[product][0] = price;
                    }
                    orders[product][1] += quantity;
                }
            }

            foreach (var item in orders)
            {
                double totalPrice = orders[item.Key][0] * orders[item.Key][1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }
        }
    }
}
