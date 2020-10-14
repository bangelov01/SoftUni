using System;

namespace _20.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int saveNum = i;
                while (saveNum > 0)
                {
                    sumOfDigits += saveNum % 10;
                    saveNum = saveNum / 10;
                }
                bool isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }
        }
    }
}
