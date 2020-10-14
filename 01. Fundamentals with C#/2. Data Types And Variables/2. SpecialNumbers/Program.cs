using System;

namespace _17._SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int saveI = i;

                while (saveI > 0)
                {
                    int digit = saveI % 10;
                    sumOfDigits += digit;
                    saveI /= 10;
                }

                bool isSpecial = sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11;

                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
