using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._ListManipulationsBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> manipulateList = new List<int>();
            manipulateList.AddRange(numbers);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split();

                switch (commandArr[0])
                {
                    case "Add":
                        manipulateList.Add(int.Parse(commandArr[1]));
                        break;
                    case "Remove":
                        manipulateList.RemoveAll(x => x == int.Parse(commandArr[1]));
                        break;
                    case "RemoveAt":
                        manipulateList.RemoveAt(int.Parse(commandArr[1]));
                        break;
                    case "Insert":
                        manipulateList.Insert(int.Parse(commandArr[2]), int.Parse(commandArr[1]));
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", manipulateList));
        }
    }
}
