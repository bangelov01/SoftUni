using System;

namespace _08.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int[] beePosition = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beePosition[0] = row;
                        beePosition[1] = col;
                    }
                }
            }

            bool isLost = false;
            bool hasEnded = false;
            int spaceToMove = 0;
            int polinatedFlowers = 0;
            string plane = "";

            while (hasEnded == false && isLost == false)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "right":

                        spaceToMove = beePosition[1] + 1;
                        plane = "horizontal";

                        if (!IsInRange(matrix, beePosition[0], spaceToMove))
                        {
                            isLost = true;
                            matrix[beePosition[0], beePosition[1]] = '.';
                            continue;
                        }
                        if (matrix[beePosition[0], spaceToMove] == 'f')
                        {
                            polinatedFlowers++;
                        }
                        else if (matrix[beePosition[0], spaceToMove] == 'O')
                        {
                            if (!IsInRange(matrix, beePosition[0], spaceToMove + 1))
                            {
                                isLost = true;
                                ClearRange(matrix, spaceToMove, beePosition, plane);
                                continue;
                            }

                            ClearRange(matrix, spaceToMove, beePosition, plane);

                            if (matrix[beePosition[0], spaceToMove + 1] == 'f')
                            {
                                polinatedFlowers++;
                            }                 
                            MoveBee(matrix, spaceToMove + 1, plane, beePosition);
                            continue;
                        }

                        MoveBee(matrix, spaceToMove, plane, beePosition);
                        break;

                    case "left":

                        spaceToMove = beePosition[1] - 1;
                        plane = "horizontal";

                        if (!IsInRange(matrix, beePosition[0], spaceToMove))
                        {
                            isLost = true;
                            matrix[beePosition[0], beePosition[1]] = '.';
                            continue;
                        }
                        if (matrix[beePosition[0], spaceToMove] == 'f')
                        {
                            polinatedFlowers++;
                        }
                        else if (matrix[beePosition[0], spaceToMove] == 'O')
                        {
                            if (!IsInRange(matrix, beePosition[0], spaceToMove - 1))
                            {
                                isLost = true;
                                ClearRange(matrix, spaceToMove, beePosition, plane);
                                continue;
                            }

                            ClearRange(matrix, spaceToMove, beePosition, plane);

                            if (matrix[beePosition[0], spaceToMove - 1] == 'f')
                            {
                                polinatedFlowers++;
                            }
                            MoveBee(matrix, spaceToMove - 1, plane, beePosition);
                            continue;
                        }

                        MoveBee(matrix, spaceToMove, plane, beePosition);
                        break;

                    case "down":

                        spaceToMove = beePosition[0] + 1;
                        plane = "vertical";

                        if (!IsInRange(matrix, spaceToMove, beePosition[1]))
                        {
                            isLost = true;
                            matrix[beePosition[0], beePosition[1]] = '.';
                            continue;
                        }
                        if (matrix[spaceToMove, beePosition[1]] == 'f')
                        {
                            polinatedFlowers++;
                        }
                        else if (matrix[spaceToMove, beePosition[1]] == 'O')
                        {
                            if (!IsInRange(matrix, spaceToMove + 1, beePosition[1]))
                            {
                                isLost = true;
                                ClearRange(matrix, spaceToMove, beePosition, plane);
                                continue;
                            }

                            ClearRange(matrix, spaceToMove, beePosition, plane);

                            if (matrix[spaceToMove + 1, beePosition[1]] == 'f')
                            {
                                polinatedFlowers++;
                            }
                            MoveBee(matrix, spaceToMove + 1, plane, beePosition);
                            continue;
                        }

                        MoveBee(matrix, spaceToMove, plane, beePosition);
                        break;
                    case "up":

                        spaceToMove = beePosition[0] - 1;
                        plane = "vertical";

                        if (!IsInRange(matrix, spaceToMove, beePosition[1]))
                        {
                            isLost = true;
                            matrix[beePosition[0], beePosition[1]] = '.';
                            continue;
                        }
                        if (matrix[spaceToMove, beePosition[1]] == 'f')
                        {
                            polinatedFlowers++;
                        }
                        else if (matrix[spaceToMove, beePosition[1]] == 'O')
                        {
                            if (!IsInRange(matrix, spaceToMove - 1, beePosition[1]))
                            {
                                isLost = true;
                                ClearRange(matrix, spaceToMove, beePosition, plane);
                                continue;
                            }

                            ClearRange(matrix, spaceToMove, beePosition, plane);

                            if (matrix[spaceToMove - 1, beePosition[1]] == 'f')
                            {
                                polinatedFlowers++;
                            }
                            MoveBee(matrix, spaceToMove - 1, plane, beePosition);
                            continue;
                        }

                        MoveBee(matrix, spaceToMove, plane, beePosition);
                        break;
                    case "End":
                        hasEnded = true;
                        break;
                }
            }

            if (isLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (polinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
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

        static bool IsInRange(char[,] matrix, int col, int row)
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

        public static void MoveBee(char[,] matrix, int spaceToMove, string plane, int[] beePosition)
        {
            matrix[beePosition[0], beePosition[1]] = '.';

            if (plane == "horizontal")
            {               
                matrix[beePosition[0], spaceToMove] = 'B';
                beePosition[1] = spaceToMove;
            }
            else
            {
                matrix[spaceToMove, beePosition[1]] = 'B';
                beePosition[0] = spaceToMove;
            }
        }

        public static void ClearRange(char[,] matrix, int spaceToMove, int[] beePosition, string plane)
        {
            matrix[beePosition[0], beePosition[1]] = '.';

            if (plane == "horizontal")
            {
                matrix[beePosition[0], spaceToMove] = '.';
            }
            else
            {
                matrix[spaceToMove, beePosition[1]] = '.';
            }
        }
    }
}
