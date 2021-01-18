using System;

namespace _06._PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[n][];
            pascalTriangle[0] = new long[1] { 1 };

            for (int row = 1; row < pascalTriangle.Length; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (col == 0)
                    {
                        pascalTriangle[row][col] = 1;
                        continue;
                    }
                    else if (col == pascalTriangle[row].Length - 1)
                    {
                        pascalTriangle[row][col] = 1;
                        break;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + 
                        pascalTriangle[row - 1][col];
                    }
                }
            }

            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                for (int j = 0; j < pascalTriangle[i].Length; j++)
                {
                    Console.Write(pascalTriangle[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
