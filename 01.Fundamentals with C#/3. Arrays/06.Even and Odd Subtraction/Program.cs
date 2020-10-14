using System;
using System.Linq;

namespace _06.Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    oddSum += numbers[i];
                }
                else
                {
                    evenSum += numbers[i];
                }
            }
            int result = evenSum - oddSum;
            Console.WriteLine(result);
        }
    }
}
