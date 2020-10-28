using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries)
                                                   .ToList();
            int initialHealth = 100;
            int bitcoins = 0;
            int roomCount = 0;

            for (int i = 0; i < input.Count; i++)
            {
                string[] room = input[i].Split(" ");

                string command = room[0];
                int number = int.Parse(room[1]);
                roomCount++;

                if (command == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                    continue;
                }
                else if (command == "potion")
                {
                    
                    if ((initialHealth + number) >= 100)
                    {
                        int remains = 100 - initialHealth;
                        Console.WriteLine($"You healed for {remains} hp.");
                        initialHealth = 100;
                    }
                    else
                    {
                        initialHealth += number;
                        Console.WriteLine($"You healed for {number} hp.");
                    }
                    Console.WriteLine($"Current health: {initialHealth} hp.");
                }
                else
                {
                    initialHealth -= number;
                    if (initialHealth <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {command}.");
                        continue;
                    }
                }
            }
            if (initialHealth > 0)
            {
                Console.WriteLine($"You've made it!\r\nBitcoins: {bitcoins}\r\nHealth: {initialHealth}");
            }
            else
            {
                Console.WriteLine($"Best room: {roomCount}");
            }
        }
    }
}
