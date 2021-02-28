using System;

namespace _10.ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            decimal length = decimal.Parse(Console.ReadLine());
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);

                box.CalculateSurfaceArea();
                box.CalculateLateralSurfaceArea();
                box.CalculateVolume();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
