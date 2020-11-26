using System;

namespace _12.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(ReturnSmallestNumberFrom(number1, number2, number3));
        }

        static int ReturnSmallestNumberFrom(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }

    }
}
