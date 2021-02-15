using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            Dictionary<int, int[]> plantPositions = new Dictionary<int, int[]>();

            string input = string.Empty;
            int positionCount = 1;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (!isInRange(matrix,row,col))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                plantPositions.Add(positionCount, new int[2] { row, col });
                positionCount++;
            }

            foreach (var position in plantPositions)
            {
                int rowPosition = position.Value[0];
                int colPosition = position.Value[1];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[rowPosition, col] += 1;
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (row == rowPosition)
                    {
                        continue;
                    }
                    matrix[row, colPosition] += 1;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool isInRange(int[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
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
