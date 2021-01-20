using System;
using System.Collections.Generic;
using System.Linq;


namespace _11._SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            string snake = Console.ReadLine();
            Queue<char> snakeQueue = new Queue<char>(snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snakeQueue.Dequeue().ToString();
                        snakeQueue.Enqueue(char.Parse(matrix[row, col]));
                    }
                }
                else
                {
                    for (int revCol = matrix.GetLength(1) - 1; revCol >= 0; revCol--)
                    {
                        matrix[row, revCol] = snakeQueue.Dequeue().ToString();
                        snakeQueue.Enqueue(char.Parse(matrix[row, revCol]));
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
