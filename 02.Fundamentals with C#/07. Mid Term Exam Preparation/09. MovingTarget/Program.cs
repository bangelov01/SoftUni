using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split();

                string action = commandArr[0];
                int index = int.Parse(commandArr[1]);
                int attribute = int.Parse(commandArr[2]);

                if (action == "Shoot")
                {
                    if (index >=0 && index < values.Count)
                    {
                        values[index] -= attribute;
                    }
                    else
                    {
                        continue;
                    }
                    if (values[index] <= 0)
                    {
                        values.RemoveAt(index);
                    }
                }
                else if (action == "Add")
                {
                    if (index >= 0 && index < values.Count)
                    {
                        values.Insert(index,attribute);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                        continue;
                    }
                }
                else if (action == "Strike")
                {
                    if (index >= 0 && index < values.Count && index - attribute >= 0 && index + attribute < values.Count)
                    {
                        int startIndex = index - attribute;
                        int count = (attribute * 2) + 1;

                        values.RemoveRange(startIndex, count);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }
                }
            }

            Console.WriteLine(string.Join("|", values));
        }
    }
}
