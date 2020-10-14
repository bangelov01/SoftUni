using System;

namespace _25.Weather_Forecast_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {

            string weather = Console.ReadLine();

            string sunnyWeather = "sunny";

            if (sunnyWeather == weather) 
            {
                Console.WriteLine("It's warm outside!");
            }
            else
            {
                Console.WriteLine("It's cold outside!");
            }          
        }
    }
}
