using System;
using System.Collections.Generic;
using System.Linq;

namespace _19._EasterShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopsToVisit = Console.ReadLine().Split(" ").ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(" ");

                string action = command[0];

                if (action == "Include")
                {
                    string shop = command[1];

                    shopsToVisit.Add(shop);
                }
                else if (action == "Visit")
                {
                    string firstOrLast = command[1];
                    int numberOfShops = int.Parse(command[2]);

                    if (numberOfShops <= shopsToVisit.Count)
                    {
                        if (firstOrLast == "first")
                        {
                            shopsToVisit.RemoveRange(0, numberOfShops);
                        }
                        else
                        {
                            int index = shopsToVisit.Count - numberOfShops;
                            shopsToVisit.RemoveRange(index, numberOfShops);
                        }
                    }
                }
                else if (action == "Prefer")
                {
                    int firstShopIndex = int.Parse(command[1]);
                    int secondShopIndex = int.Parse(command[2]);

                    if ((firstShopIndex >= 0 && firstShopIndex <= shopsToVisit.Count - 1) 
                       && (secondShopIndex >=0 && secondShopIndex <= shopsToVisit.Count - 1))
                    {
                        string hold = shopsToVisit[firstShopIndex];
                        shopsToVisit[firstShopIndex] = shopsToVisit[secondShopIndex];
                        shopsToVisit[secondShopIndex] = hold;
                    }
                }
                else if (action == "Place")
                {
                    string shop = command[1];
                    int index = int.Parse(command[2]) + 1;
                    
                    if (index >= 0 && index <= shopsToVisit.Count-1)
                    {
                        shopsToVisit.Insert(index, shop);
                    }
                }
            }

            Console.WriteLine($"Shops left:\r\n{string.Join(" ", shopsToVisit)}");
        }
    }
}
