using System;
using System.Linq;

namespace _12._JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfRows = int.Parse(Console.ReadLine());
y();
                jagged[row] = nums;
            double[][] jagged = new double[numOfRows][];

            for (int row = 0; row < jagged.Length; row++)
            {
                double[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(double.Parse).ToArr
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int colPlus = 0; colPlus < jagged[row + 1].Length; colPlus++)
                    {
                        jagged[row + 1][colPlus] /= 2;
                    }
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = inputArr[0];

                if (action == "Add")
                {
                    int row = int.Parse(inputArr[1]);
                    int col = int.Parse(inputArr[2]);
                    int value = int.Parse(inputArr[3]);

                    if (IsValid(jagged, inputArr, row, col))
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (action == "Subtract")
                {
                    int row = int.Parse(inputArr[1]);
                    int col = int.Parse(inputArr[2]);
                    int value = int.Parse(inputArr[3]);

                    if (IsValid(jagged, inputArr, row, col))
                    {
                        jagged[row][col] -= value;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }

        static bool IsValid(double[][] jagged, string[] inputArr, int row, int col)
        {

            if (row >= 0 && row < jagged.Length && col < jagged[row].Length && col >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
