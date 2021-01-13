using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stackNums = new Stack<int>(nums);

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splittedCommand = command.Split();

                string action = splittedCommand[0];

                if (action == "add")
                {
                    int firstNum = int.Parse(splittedCommand[1]);
                    int secondNum = int.Parse(splittedCommand[2]);

                    stackNums.Push(firstNum);
                    stackNums.Push(secondNum);
                }
                if (action == "remove")
                {
                    int countToRemove = int.Parse(splittedCommand[1]);

                    if (countToRemove > stackNums.Count)
                    {
                        continue;
                    }
                    else
                    {
                        while (countToRemove > 0)
                        {
                            stackNums.Pop();
                            countToRemove--;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {stackNums.Sum()}");
        }
    }
}
