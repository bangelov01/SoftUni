using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, Func<int, int>> numberManipulation = new Dictionary<string, Func<int, int>>()
            {
                { "add", n => n + 1 },
                { "multiply", n => n * 2 },
                { "subtract", n => n - 1 }
            };
            string command = string.Empty;
            Action<int[],Func<int,int>> execute = ExecuteCommand;
            Action<int[]> printer = p =>
            {
                Console.WriteLine(string.Join(" ", nums));
            };

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    printer(nums);
                }
                else if (numberManipulation.ContainsKey(command))
                {
                    execute(nums,numberManipulation[command].Invoke);
                }
            }
        }

        static void ExecuteCommand(int[] nums, Func<int,int> func)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = func(nums[i]);
            }
        }
    }
}
