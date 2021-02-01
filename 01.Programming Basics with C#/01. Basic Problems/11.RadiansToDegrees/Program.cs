using System;

namespace _11.Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double deg = rad * 180 / Math.PI;
            double result = Math.Round(deg);

            Console.WriteLine(result);
        }
    }
}
