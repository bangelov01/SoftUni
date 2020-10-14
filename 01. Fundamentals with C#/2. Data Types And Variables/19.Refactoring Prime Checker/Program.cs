using System;

namespace _34.Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            for (int i = 2; i <= inputNumber; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                string result = isPrime.ToString();
                Console.WriteLine($"{i} -> {result.ToLower()}");
            }

        }
    }
}
