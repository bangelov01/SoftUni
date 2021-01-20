using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> coordinatesQueue = new Queue<string>(coordinates);

            while (coordinatesQueue.Count > 0)
            {
                string[] cell = coordinatesQueue.Dequeue().Split(",",StringSplitOptions.RemoveEmptyEntries);
                int rowCell = int.Parse(cell[0]);
                int colCell = int.Parse(cell[1]);

                if (matrix[rowCell,colCell] > 0)
                {
                    if (isInRange(matrix, rowCell - 1, colCell + 1))
                    {
                        if (matrix[rowCell - 1, colCell + 1] > 0)
                        {
                            matrix[rowCell - 1, colCell + 1] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell - 1, colCell))
                    {
                        if (matrix[rowCell - 1, colCell] > 0)
                        {
                            matrix[rowCell - 1, colCell] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell - 1, colCell - 1))
                    {
                        if (matrix[rowCell - 1, colCell - 1] > 0)
                        {
                            matrix[rowCell - 1, colCell - 1] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell + 1, colCell + 1))
                    {
                        if (matrix[rowCell + 1, colCell + 1] > 0)
                        {
                            matrix[rowCell + 1, colCell + 1] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell + 1, colCell))
                    {
                        if (matrix[rowCell + 1, colCell] > 0)
                        {
                            matrix[rowCell + 1, colCell] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell + 1, colCell - 1))
                    {
                        if (matrix[rowCell + 1, colCell - 1] > 0)
                        {
                            matrix[rowCell + 1, colCell - 1] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell, colCell + 1))
                    {
                        if (matrix[rowCell, colCell + 1] > 0)
                        {
                            matrix[rowCell, colCell + 1] -= matrix[rowCell, colCell];
                        }
                    }
                    if (isInRange(matrix, rowCell, colCell - 1))
                    {
                        if (matrix[rowCell, colCell - 1] > 0)
                        {
                            matrix[rowCell, colCell - 1] -= matrix[rowCell, colCell];
                        }
                    }

                    matrix[rowCell, colCell] = 0;
                }
            }

            int aliveCells = 0;
            int sumOfAlive = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] > 0)
                    {
                        aliveCells++;
                        sumOfAlive += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAlive}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        static bool isInRange(int[,] matrix, int col, int row)
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
