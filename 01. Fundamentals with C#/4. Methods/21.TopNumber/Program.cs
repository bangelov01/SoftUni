using System;

namespace _21.TopNumber
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (CheckSumOfDigits(i) && ChechForOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool CheckSumOfDigits(int number)
        {
            int sum = 0;
            int holder = 0;
            while (number > 0)
            {
                holder = number % 10;
                sum += holder;
                number /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ChechForOneOddDigit(int number)
        {
            int holder = 0;
            while (number > 0)
            {
                holder = number % 10;
                if (holder % 2 == 1)
                {
                    return true;
                }
                number /= 10;
            }
            return false;
        }
    }
}
