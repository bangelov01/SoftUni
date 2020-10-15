using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            int index = 1;

            foreach (string item in products)
            {
                Console.WriteLine($"{index}.{item}");
                index++;
            }
        }
    }
}
