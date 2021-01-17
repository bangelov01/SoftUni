using System;
using System.Linq;

namespace _01._SumMatrixElements
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
                int[] colNums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colNums[col];
                    sum += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
