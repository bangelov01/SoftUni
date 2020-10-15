using System;
using System.Collections.Generic;
using System.Linq;


namespace _07._ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> originalList = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            List<int> manipulateList = new List<int>();
            manipulateList.AddRange(originalList);

            ReturnManipulation(originalList, manipulateList);
        }

        static void ReturnManipulation(List<int> originalList, List<int> manipulateList)
        {
            string command = string.Empty;

            bool ischanged = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArr = command.Split();
                
                switch (commandArr[0])
                {
                    case "Add":
                        originalList.Add(int.Parse(commandArr[1]));
                        ischanged = true;
                        break;
                    case "Remove":
                        originalList.RemoveAll(x => x == int.Parse(commandArr[1]));
                        ischanged = true;
                        break;
                    case "RemoveAt":
                        originalList.RemoveAt(int.Parse(commandArr[1]));
                        ischanged = true;
                        break;
                    case "Insert":
                        originalList.Insert(int.Parse(commandArr[2]), int.Parse(commandArr[1]));
                        ischanged = true;
                        break;
                    case "Contains":
                        if (manipulateList.Contains(int.Parse(commandArr[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", manipulateList.Where(x => x % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", manipulateList.Where(x => x % 2 == 1)));
                        break;
                    case "GetSum":
                        Console.WriteLine(string.Join(" ", manipulateList.Sum()));
                        break;
                    case "Filter":
                        PrintFiltered(manipulateList, commandArr[1], int.Parse(commandArr[2]));
                        break;
                }
            }
            if (ischanged)
            {
                Console.WriteLine(string.Join(" ", originalList));
            }
        }
        static void PrintFiltered (List<int> manipulateList, string operat, int number)
        {
            switch (operat)
            {
                case ">":
                    Console.WriteLine(string.Join(" ", manipulateList.Where(x => x > number)));
                    break;
                case "<":
                    Console.WriteLine(string.Join(" ", manipulateList.Where(x => x < number)));
                    break;
                case "<=":
                    Console.WriteLine(string.Join(" ", manipulateList.Where(x => x <= number)));
                    break;
                default:
                    Console.WriteLine(string.Join(" ", manipulateList.Where(x => x >= number)));
                    break;
            }
        }
    }
}
