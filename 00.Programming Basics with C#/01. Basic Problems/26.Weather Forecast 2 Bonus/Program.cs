using System;

namespace _26.Weather_Forecast_2_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());

            if (degrees >= 26.00 && degrees <= 35.00)
            {
                Console.WriteLine("Hot");
            }
            else if (degrees > 20.00 && degrees < 26.00)
            {
                Console.WriteLine("Warm");
            }
            else if (degrees >= 15.00 && degrees <= 20.00)
            {
                Console.WriteLine("Mild");
            }
            else if (degrees >= 12.00 && degrees < 15.00)
            {
                Console.WriteLine("Cool");
            }
            else if (degrees >= 5.00 && degrees < 12.00)
            {
                Console.WriteLine("Cold");
            }
            else
            {
                Console.WriteLine("unknown");
            }

        }
    }
}
