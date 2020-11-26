using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                      .Select(int.Parse)
                      .ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split();

                if (commandArr[0] == "Add")
                {
                    numbers.Add(int.Parse(commandArr[1]));
                }
                else if (commandArr[0] == "Insert")
                {
                    int index = int.Parse(commandArr[2]);

                    if (IsInside(index, numbers.Count))
                    {
                        numbers.Insert(index, int.Parse(commandArr[1]));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandArr[0] == "Remove")
                {
                    int index = int.Parse(commandArr[1]);

                    if (IsInside(index, numbers.Count))
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (commandArr[0] == "Shift")
                {
                    if (commandArr[1] == "left")
                    {
                        int count = int.Parse(commandArr[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int firstNumber = numbers[0];

                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }
                            numbers[numbers.Count - 1] = firstNumber;
                        }
                    }
                    else
                    {
                        int count = int.Parse(commandArr[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int lastNumber = numbers[numbers.Count - 1];

                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }
                            numbers[0] = lastNumber;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool IsInside (int index, int count)
        {
            return index >= 0 && index <= count;
        }
    }
}
