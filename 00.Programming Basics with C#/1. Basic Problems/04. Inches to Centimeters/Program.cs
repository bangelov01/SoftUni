using System;

namespace _04._Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberInCm = double.Parse(Console.ReadLine());
            double numberInInch = numberInCm * 2.54;

            Console.WriteLine(numberInInch);
        }
    }
}
