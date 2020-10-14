using System;

namespace _19._FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = decimal.Parse(Console.ReadLine());
            decimal b = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"{ReturnFactorialOf(a)/ ReturnFactorialOf(b):f2}");
            
        }

        static decimal ReturnFactorialOf (decimal number)
        {
            decimal result = 1;

            for (decimal i = number; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
    }
}
