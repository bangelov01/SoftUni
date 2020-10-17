using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonsList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split();

                if (commandArr[0] == "Add")
                {
                    wagonsList.Add(int.Parse(commandArr[1]));
                }
                else
                {
                    for (int i = 0; i < wagonsList.Count; i++)
                    {
                        if ((wagonsList[i] + int.Parse(commandArr[0])) <= maxCapacity)
                        {
                            wagonsList[i] += int.Parse(commandArr[0]);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagonsList));
        }
    }
}
