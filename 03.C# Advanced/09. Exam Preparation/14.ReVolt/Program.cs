using System;

namespace _14.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int numOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int[] startCoordinates = new int[2];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'f')
                    {
                        startCoordinates[0] = row;
                        startCoordinates[1] = col;
                    }
                }
            }

            bool isFinished = false;

            while (numOfCommands > 0 && isFinished == false)
            {
                string command = Console.ReadLine();
                int oldRow = startCoordinates[0];
                int oldCol = startCoordinates[1];

                matrix[startCoordinates[0], startCoordinates[1]] = '-';
                CheckMove(matrix, command, startCoordinates);
                IsInRangeAndRedirect(matrix, startCoordinates, command);
                if (matrix[startCoordinates[0], startCoordinates[1]] == 'T')
                {
                    startCoordinates[0] = oldRow;
                    startCoordinates[1] = oldCol;
                    matrix[startCoordinates[0], startCoordinates[1]] = 'f';
                    continue;
                }
                if (matrix[startCoordinates[0], startCoordinates[1]] == 'B')
                {
                    CheckMove(matrix, command, startCoordinates);
                    IsInRangeAndRedirect(matrix, startCoordinates, command);
                }
                if (matrix[startCoordinates[0], startCoordinates[1]] == 'F')
                {
                    isFinished = true;                    
                }
                matrix[startCoordinates[0], startCoordinates[1]] = 'f';
                numOfCommands--;
            }

            if (isFinished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsInRangeAndRedirect(char[,] matrix, int[] startCoordinates, string command)
        {
            if (startCoordinates[0] >= 0 && startCoordinates[0] < matrix.GetLength(0) && startCoordinates[1] >= 0 && startCoordinates[1] < matrix.GetLength(1))
            {
                return true;
            }
            else
            {
                switch (command)
                {
                    case "right": startCoordinates[1] = 0; break;
                    case "left": startCoordinates[1] = matrix.GetLength(0) - 1; break;
                    case "up": startCoordinates[0] = matrix.GetLength(1) - 1; break;
                    case "down": startCoordinates[0] = 0; break;
                }

                return false;
            }
        }

        static void CheckMove(char[,] matrix, string command, int[] startCoordinates)
        {
            switch (command)
            {
                case "right": startCoordinates[1] += 1; break;
                case "left": startCoordinates[1] -= 1; break;
                case "up": startCoordinates[0] -= 1; break;
                case "down": startCoordinates[0] += 1; break;
            }
        }
    }
}
