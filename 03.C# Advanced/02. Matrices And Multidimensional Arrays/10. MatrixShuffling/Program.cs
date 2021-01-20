using System;
using System.Linq;


namespace _10._MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (ISWithinBounds(matrix, commandArr))
                {
                    int row1 = int.Parse(commandArr[1]);
                    int col1 = int.Parse(commandArr[2]);
                    int row2 = int.Parse(commandArr[3]);
                    int col2 = int.Parse(commandArr[4]);

                    string holder = matrix[row2, col2];
                    matrix[row2, col2] = matrix[row1, col1];
                    matrix[row1, col1] = holder;

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row,col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static bool ISWithinBounds(string[,] matrix, string[] commandArr)
        {
            if (commandArr.Length > 5 || commandArr[0] != "swap" || int.Parse(commandArr[1]) > matrix.GetLength(0) ||
               int.Parse(commandArr[1]) < 0 || int.Parse(commandArr[2]) > matrix.GetLength(1) ||
               int.Parse(commandArr[2]) < 0 || int.Parse(commandArr[3]) > matrix.GetLength(0) ||
               int.Parse(commandArr[3]) < 0 || int.Parse(commandArr[4]) > matrix.GetLength(1) ||
               int.Parse(commandArr[4]) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
