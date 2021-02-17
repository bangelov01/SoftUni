using System;

namespace _11.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int[] snakeCoords = new int[2];
            int[][] burrowCords = new int[][]
                {
                    new int[] { 0, 0},
                    new int[] { 0, 0},
                };

            int burrowCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        snakeCoords[0] = row;
                        snakeCoords[1] = col;
                    }
                    else if (input[col] == 'B')
                    {
                        burrowCount++;
                        switch (burrowCount)
                        {
                            case 1:
                                burrowCords[0][0] = row;
                                burrowCords[0][1] = col;
                                break;
                            case 2:
                                burrowCords[1][0] = row;
                                burrowCords[1][1] = col;
                                break;
                        }
                    }
                }
            }

            int foodCount = 0;
            bool isOut = false;

            while (foodCount < 10 && isOut == false)
            {
                string input = Console.ReadLine();
                int coordToChange = 0;

                switch (input)
                {
                    case "right":

                        coordToChange = snakeCoords[1] + 1;

                        if (!IsInRange(matrix,snakeCoords[0], coordToChange))
                        {
                            isOut = true;
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            continue;
                        }
                        if (matrix[snakeCoords[0], coordToChange] == '*')
                        {
                            foodCount++;
                        }
                        else if (matrix[snakeCoords[0], coordToChange] == 'B')
                        {
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            matrix[snakeCoords[0], coordToChange] = '.';

                            if (snakeCoords[0] == burrowCords[0][0] && coordToChange == burrowCords[0][1])
                            {
                                snakeCoords[0] = burrowCords[1][0];
                                snakeCoords[1] = burrowCords[1][1];
                            }
                            else
                            {
                                snakeCoords[0] = burrowCords[0][0];
                                snakeCoords[1] = burrowCords[0][1];
                            }

                            matrix[snakeCoords[0], snakeCoords[1]] = 'S';
                            continue;
                        }

                        matrix[snakeCoords[0], snakeCoords[1]] = '.';
                        matrix[snakeCoords[0], coordToChange] = 'S';
                        snakeCoords[1] = coordToChange;
                        break;

                    case "left":

                        coordToChange = snakeCoords[1] - 1;

                        if (!IsInRange(matrix, snakeCoords[0], coordToChange))
                        {
                            isOut = true;
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            continue;
                        }
                        if (matrix[snakeCoords[0], coordToChange] == '*')
                        {
                            foodCount++;
                        }
                        else if (matrix[snakeCoords[0], coordToChange] == 'B')
                        {
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            matrix[snakeCoords[0], coordToChange] = '.';

                            if (snakeCoords[0] == burrowCords[0][0] && coordToChange == burrowCords[0][1])
                            {
                                snakeCoords[0] = burrowCords[1][0];
                                snakeCoords[1] = burrowCords[1][1];
                            }
                            else
                            {
                                snakeCoords[0] = burrowCords[0][0];
                                snakeCoords[1] = burrowCords[0][1];
                            }

                            matrix[snakeCoords[0], snakeCoords[1]] = 'S';
                            continue;
                        }

                        matrix[snakeCoords[0], snakeCoords[1]] = '.';
                        matrix[snakeCoords[0], coordToChange] = 'S';
                        snakeCoords[1] = coordToChange;
                        break;

                    case "down":

                        coordToChange = snakeCoords[0] + 1;

                        if (!IsInRange(matrix, coordToChange, snakeCoords[1]))
                        {
                            isOut = true;
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            continue;
                        }
                        if (matrix[coordToChange, snakeCoords[1]] == '*')
                        {
                            foodCount++;
                        }
                        else if (matrix[coordToChange, snakeCoords[1]] == 'B')
                        {
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            matrix[coordToChange, snakeCoords[1]] = '.';

                            if (coordToChange == burrowCords[0][0] && snakeCoords[1] == burrowCords[0][1])
                            {
                                snakeCoords[0] = burrowCords[1][0];
                                snakeCoords[1] = burrowCords[1][1];
                            }
                            else
                            {
                                snakeCoords[0] = burrowCords[0][0];
                                snakeCoords[1] = burrowCords[0][1];
                            }

                            matrix[snakeCoords[0], snakeCoords[1]] = 'S';
                            continue;
                        }

                        matrix[snakeCoords[0], snakeCoords[1]] = '.';
                        matrix[coordToChange, snakeCoords[1]] = 'S';
                        snakeCoords[0] = coordToChange;
                        break;

                    case "up":

                        coordToChange = snakeCoords[0] - 1;

                        if (!IsInRange(matrix, coordToChange, snakeCoords[1]))
                        {
                            isOut = true;
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            continue;
                        }
                        if (matrix[coordToChange, snakeCoords[1]] == '*')
                        {
                            foodCount++;
                        }
                        else if (matrix[coordToChange, snakeCoords[1]] == 'B')
                        {
                            matrix[snakeCoords[0], snakeCoords[1]] = '.';
                            matrix[coordToChange, snakeCoords[1]] = '.';

                            if (coordToChange == burrowCords[0][0] && snakeCoords[1] == burrowCords[0][1])
                            {
                                snakeCoords[0] = burrowCords[1][0];
                                snakeCoords[1] = burrowCords[1][1];
                            }
                            else
                            {
                                snakeCoords[0] = burrowCords[0][0];
                                snakeCoords[1] = burrowCords[0][1];
                            }

                            matrix[snakeCoords[0], snakeCoords[1]] = 'S';
                            continue;
                        }

                        matrix[snakeCoords[0], snakeCoords[1]] = '.';
                        matrix[coordToChange, snakeCoords[1]] = 'S';
                        snakeCoords[0] = coordToChange;
                        break;
                }
            }

            if (isOut)
            {
                Console.WriteLine("Game over!");
            }
            if (foodCount >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCount}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
        static bool IsInRange(char[,] matrix, int row, int col)
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
