using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsNum = int.Parse(Console.ReadLine());

            List<string> listOfGuests = new List<string>();

            for (int i = 0; i < commandsNum; i++)
            {
                string[] guestStatus = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (guestStatus.Length == 3)
                {
                    if (listOfGuests.Contains(guestStatus[0]))
                    {
                        Console.WriteLine($"{guestStatus[0]} is already in the list!");
                    }
                    else
                    {
                        listOfGuests.Add(guestStatus[0]);
                    }
                }
                else
                {
                    if (listOfGuests.Contains(guestStatus[0]))
                    {
                        listOfGuests.Remove(guestStatus[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{guestStatus[0]} is not in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine,listOfGuests));
        }
    }
}
