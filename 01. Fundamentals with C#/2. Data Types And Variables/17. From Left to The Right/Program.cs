using System;
using System.Linq;

namespace _32.From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                long[] numbers = Console.ReadLine().Split(" ")
                    .Select(long.Parse)
                    .ToArray();

                long biggerNumber = 0;
                if (numbers[0] > numbers[1])
                {
                    biggerNumber = numbers[0];
                }
                else
                {
                    biggerNumber = numbers[1];
                }

                long sumOfDigits = 0;

                while (biggerNumber != 0)
                {
                    sumOfDigits += biggerNumber % 10;
                    biggerNumber /= 10;
                }

                Console.WriteLine(Math.Abs(sumOfDigits));
            }
        }
    }
}
