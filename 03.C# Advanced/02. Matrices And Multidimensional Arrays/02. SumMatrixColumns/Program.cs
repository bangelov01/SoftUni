using System;
using System.Linq;

namespace _02._SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] colAndRowCount = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = colAndRowCount[0];
            int cols = colAndRowCount[1];

            int[,] matrix = new int[rows, cols];

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum = 0;
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row,col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
