using System;

namespace _06.CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateArea(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
        }

        static int CalculateArea(int width, int height)
        {
            return width * height;
        }
    }
}
