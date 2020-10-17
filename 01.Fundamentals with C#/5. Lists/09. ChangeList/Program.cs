using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            List<int> manipulateNumbers = new List<int>();
            manipulateNumbers.AddRange(numbers);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split();

                if (commandArr[0] == "Delete")
                {
                    manipulateNumbers.RemoveAll(x => x == int.Parse(commandArr[1]));
                }
                else
                {
                    manipulateNumbers.Insert(int.Parse(commandArr[2]), int.Parse(commandArr[1]));
                }
            }

            Console.WriteLine(string.Join(" ", manipulateNumbers));
        }
    }
}
