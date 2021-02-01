using System;

namespace _20.Celsius_to_Fahrenheit_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());

            double convertToF = celsius * 9 / 5 + 32;

            Console.WriteLine($"{convertToF:f2}");
        }
    }
}
