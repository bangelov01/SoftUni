using System;
using System.Diagnostics.CodeAnalysis;

namespace _13._Game_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currBalance = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            double price = 0;
            double totalSpent = 0;
            bool isOut = false;

            while (game != "Game Time")
            {
                switch (game)
                {
                    case "OutFall 4": price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;
                    default:
                        Console.WriteLine("Not Found");
                        game = Console.ReadLine();
                        continue;
                }
                if (price > currBalance)
                {
                    Console.WriteLine("Too Expensive");
                    game = Console.ReadLine();
                    continue;
                }
                else
                {
                    totalSpent += price;
                    currBalance -= price;
                    Console.WriteLine($"Bought {game}");
                }
                game = Console.ReadLine();
                if (currBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    isOut = true;
                }
            }
            if (!isOut)
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currBalance:f2}");
            }
        }
    }
}
