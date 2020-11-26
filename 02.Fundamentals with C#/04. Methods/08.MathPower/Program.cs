using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RaiseToPower(double.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }

        static double RaiseToPower (double number, int power)
        {
            double result = 1d;

            for (int i = 1; i <= power; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
