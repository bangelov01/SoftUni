using System;

namespace _13._KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;

            while (true)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            if (isSpaceContained(board, row + 2, col + 1))
                            {
                                if (board[row + 2, col + 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            if (isSpaceContained(board, row + 2, col - 1))
                            {
                                if (board[row + 2, col - 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                            if (isSpaceContained(board, row - 2, col + 1))
                            {
                                if (board[row - 2, col + 1] == 'K')
                                {
                                    currentKnightsInDanger++;

                                }
                            }
                            if (isSpaceContained(board, row - 2, col - 1))
                            {
                                if (board[row - 2, col - 1] == 'K')
                                {
                                    currentKnightsInDanger++;

                                }
                            }
                            if (isSpaceContained(board, row - 1, col + 2))
                            {
                                if (board[row - 1, col + 2] == 'K')
                                {
                                    currentKnightsInDanger++;

                                }
                            }
                            if (isSpaceContained(board, row - 1, col - 2))
                            {
                                if (board[row - 1, col - 2] == 'K')
                                {
                                    currentKnightsInDanger++;

                                }
                            }
                            if (isSpaceContained(board, row + 1, col + 2))
                            {
                                if (board[row + 1, col + 2] == 'K')
                                {
                                    currentKnightsInDanger++;

                                }
                            }
                            if (isSpaceContained(board, row + 1, col - 2))
                            {
                                if (board[row + 1, col - 2] == 'K')
                                {
                                    currentKnightsInDanger++;

                                }
                            }
                        }
                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }
                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    board[mostDangerousKnightRow, mostDangerousKnightCol] = '0';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        static bool isSpaceContained(char[,] board, int col, int row)
        {
            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
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
