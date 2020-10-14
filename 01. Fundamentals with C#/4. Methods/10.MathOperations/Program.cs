using System;

namespace _10.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MultiplyEvenAndOddDigits(Math.Abs(int.Parse(Console.ReadLine()))));
        }

        static int MultiplyEvenAndOddDigits (int number)
        {
            return GetSumOfDigits(number, 0) * GetSumOfDigits(number, 1);
        }

        static int GetSumOfDigits (int number, int isOdd)
        {
            string convert = Convert.ToString(number);
            int sum = 0;
            for (int i = 0; i < convert.Length; i++)
            {
                int num = int.Parse(convert[i].ToString());

                if (num % 2 == isOdd)
                {
                    sum += num;
                }
            }

            return sum;
        }
    }
}
