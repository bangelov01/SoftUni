using System;

namespace _33._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOne = double.Parse(Console.ReadLine());
            double numberTwo = double.Parse(Console.ReadLine());
            double epConstant = 0.000001;

            double result = Math.Abs(numberOne - numberTwo);

            if (result <= epConstant)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
