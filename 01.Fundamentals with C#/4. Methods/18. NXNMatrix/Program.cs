using System;

namespace _18._NXNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                PrintMatrixWith(number);
                Console.WriteLine();
            }
        }

        static void PrintMatrixWith (int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
