using System;

namespace _16.AddAndSubstract
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(ReturnSubtract(ReturnSum(number1, number2), number3));

        }

        static int ReturnSum(int a, int b)
        {
            return a + b;
        }

        static int ReturnSubtract(int a, int b)
        {
            return a - b;
        }
    }
}
