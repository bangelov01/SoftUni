using System;

namespace _20._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long triangleRows = long.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[triangleRows][];

            jaggedArray[0] = new long[1];
            jaggedArray[0][0] = 1;

            for (int row = 1; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;
                jaggedArray[row][jaggedArray[row].Length - 1] = 1;

                for (int col = 1; col < jaggedArray[row].Length -1; col++)
                {
                    long leftDiagonal = jaggedArray[row - 1][col - 1];
                    long rightDecimal = jaggedArray[row - 1][col];

                    jaggedArray[row][col] = leftDiagonal + rightDecimal;
                }
            }

            for (int row = 0; row < triangleRows; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }
    }
}
