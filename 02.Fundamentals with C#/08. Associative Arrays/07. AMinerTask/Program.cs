using System;
using System.Collections.Generic;

namespace _07._AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            Dictionary<string, int> collection = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "stop")
            {
                string metal = command;
                int quantity = int.Parse(Console.ReadLine());

                if (!collection.ContainsKey(metal))
                {
                    collection.Add(metal, quantity);
                }
                else
                {
                    collection[metal] += quantity;
                }
            }

            foreach (var metal in collection)
            {
                Console.WriteLine($"{metal.Key} -> {metal.Value}");
            }
        }
    }
}
