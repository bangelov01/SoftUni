using System;
using System.Linq;

namespace _05._JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsNum = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rowsNum][];

            for (int rows = 0; rows < jagged.Length; rows++)
            {
                int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                jagged[rows] = new int[nums.Length];

                for (int col = 0; col < jagged[rows].Length; col++)
                {
                    jagged[rows][col] = nums[col];
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArray = input.Split();

                string action = inputArray[0];
                int row = int.Parse(inputArray[1]);
                int col = int.Parse(inputArray[2]);
                int value = int.Parse(inputArray[3]);

                if ((row >= 0 && row < jagged.Length) && (col >= 0 && col < jagged[row].Length))
                {
                    if (action == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    if (action == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
