using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int row = size[0];
            int col = size[1];

            int[,] matrix = new int[row, col];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = nums[cols];
                }
            }

            int totalSum = int.MinValue;
            int currentSum = 0;
            int colIndex = 0;
            int rowIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {

                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    currentSum += matrix[rows, cols] + matrix[rows, cols + 1] + 
                    matrix[rows + 1, cols] + matrix[rows + 1, cols + 1];

                    if (currentSum > totalSum)
                    {
                        totalSum = currentSum;
                        rowIndex = rows;
                        colIndex = cols;
                    }

                    currentSum = 0;
                }
            }

            Console.WriteLine($"{matrix[rowIndex,colIndex]} {matrix[rowIndex, colIndex + 1]}" +
                $"\r\n{matrix[rowIndex + 1, colIndex]} {matrix[rowIndex + 1, colIndex + 1]}");
            Console.WriteLine(totalSum);
        }
    }
}
