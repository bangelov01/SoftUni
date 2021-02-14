using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            Dictionary<string, int[]> pillars = new Dictionary<string, int[]>();
            int[] startCoordinates = new int[2];

            char[,] matrix = new char[size, size];
            string name = "First";

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string matrixInput = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixInput[col];

                    if (matrixInput[col] == 'O')
                    {
                        if (!pillars.ContainsKey(name))
                        {
                            pillars.Add(name, new int[] { row, col });
                            name = "Second";
                        }
                    }
                    if (matrixInput[col] == 'S')
                    {
                        startCoordinates[0] = row;
                        startCoordinates[1] = col;
                    }
                }
            }

            int money = 0;
            bool isOut = false;
            int coordToChange = 0;
            string plane = string.Empty;

            while (money < 50 && isOut == false)
            {
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "right":
                        coordToChange = startCoordinates[1] + 1;
                        plane = "horizontal";

                        if (!isInRange(matrix, startCoordinates[0], coordToChange))
                        {
                            isOut = true;
                            matrix[startCoordinates[0], startCoordinates[1]] = '-';
                            continue;
                        }

                        else if (matrix[startCoordinates[0], coordToChange] == 'O')
                        {
                            ConfigureO(plane, coordToChange, matrix, pillars, startCoordinates);
                            continue;
                        }
                        else if (char.IsDigit(matrix[startCoordinates[0], startCoordinates[1] + 1]))
                        {
                            money += int.Parse(matrix[startCoordinates[0], coordToChange].ToString());
                        }

                        MoveS(matrix, startCoordinates, plane, coordToChange);

                        break;
                    case "left":
                        coordToChange = startCoordinates[1] - 1;
                        plane = "horizontal";

                        if (!isInRange(matrix, startCoordinates[0], coordToChange))
                        {
                            isOut = true;
                            matrix[startCoordinates[0], startCoordinates[1]] = '-';
                            continue;
                        }
                        else if (matrix[startCoordinates[0], coordToChange] == 'O')
                        {
                            ConfigureO(plane, coordToChange, matrix, pillars, startCoordinates);
                            continue;
                        }
                        else if (char.IsDigit(matrix[startCoordinates[0], coordToChange]))
                        {
                            money += int.Parse(matrix[startCoordinates[0], coordToChange].ToString());
                        }

                        MoveS(matrix, startCoordinates, plane, coordToChange);

                        break;
                    case "up":
                        coordToChange = startCoordinates[0] - 1;
                        plane = "vertical";

                        if (!isInRange(matrix, coordToChange, startCoordinates[1]))
                        {
                            isOut = true;
                            matrix[startCoordinates[0], startCoordinates[1]] = '-';
                            continue;
                        }
                        else if (matrix[coordToChange, startCoordinates[1]] == 'O')
                        {
                            ConfigureO(plane, coordToChange, matrix, pillars, startCoordinates);
                            continue;
                        }
                        else if (char.IsDigit(matrix[coordToChange, startCoordinates[1]]))
                        {
                            money += int.Parse(matrix[coordToChange, startCoordinates[1]].ToString());
                        }

                        MoveS(matrix, startCoordinates, plane, coordToChange);

                        break;
                    case "down":
                        coordToChange = startCoordinates[0] + 1;
                        plane = "vertical";

                        if (!isInRange(matrix, coordToChange, startCoordinates[1]))
                        {
                            isOut = true;
                            matrix[startCoordinates[0], startCoordinates[1]] = '-';
                            continue;
                        }
                        else if (matrix[coordToChange, startCoordinates[1]] == 'O')
                        {
                            ConfigureO(plane, coordToChange, matrix, pillars, startCoordinates);
                            continue;
                        }
                        else if (char.IsDigit(matrix[coordToChange, startCoordinates[1]]))
                        {
                            money += int.Parse(matrix[coordToChange, startCoordinates[1]].ToString());
                        }

                        MoveS(matrix, startCoordinates, plane, coordToChange);

                        break;
                }
            }

            if (money >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {money}");
            }
            if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
                Console.WriteLine($"Money: {money}");
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

        static bool isInRange(char[,] matrix, int col, int row)
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

        static void ConfigureO(string plane, int coordToChange, char[,] matrix, Dictionary<string, int[]> pillars, int[] startCoordinates)
        {
            if (plane == "horizontal")
            {
                matrix[startCoordinates[0], startCoordinates[1]] = '-';
                matrix[startCoordinates[0], coordToChange] = '-';

                foreach (var pillar in pillars)
                {
                    if (pillar.Value[0] != startCoordinates[0] && pillar.Value[1] != coordToChange)
                    {
                        startCoordinates[0] = pillar.Value[0];
                        startCoordinates[1] = pillar.Value[1];
                    }
                }
                matrix[startCoordinates[0], startCoordinates[1]] = 'S';
            }
            else
            {
                matrix[startCoordinates[0], startCoordinates[1]] = '-';
                matrix[coordToChange, startCoordinates[1]] = '-';

                foreach (var pillar in pillars)
                {
                    if (pillar.Value[0] != coordToChange && pillar.Value[1] != startCoordinates[1])
                    {
                        startCoordinates[0] = pillar.Value[0];
                        startCoordinates[1] = pillar.Value[1];
                    }
                }
                matrix[startCoordinates[0], startCoordinates[1]] = 'S';
            }
        }

        static void MoveS(char[,] matrix, int[] startCoordinates, string plane, int coordToChange)
        {
            matrix[startCoordinates[0], startCoordinates[1]] = '-';

            if (plane == "horizontal")
            {
                matrix[startCoordinates[0], coordToChange] = 'S';
                startCoordinates[1] = coordToChange;
            }
            else
            {               
                matrix[coordToChange, startCoordinates[1]] = 'S';
                startCoordinates[0] = coordToChange;
            }
        }
    }
}
