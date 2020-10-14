using System;

namespace _20.Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            int kilometers = int.Parse(Console.ReadLine());
            string timePeriod = Console.ReadLine();


            double taxiDay = (kilometers * 0.79) + 0.70;
            double taxiNight = (kilometers * 0.90) + 0.70;
            double bus = kilometers * 0.09;
            double train = kilometers * 0.06;

            if (kilometers < 20 && timePeriod == "day")
            {
                Console.WriteLine($"{taxiDay:f2}");
            }
            else if (kilometers < 20 && timePeriod == "night")
            {
                Console.WriteLine($"{taxiNight:f2}");
            }
            else if (kilometers >= 20 && kilometers < 100)
            {
                Console.WriteLine($"{bus:f2}");
            }
            else if (kilometers >= 100)
            {
                Console.WriteLine($"{train:f2}");
            }
        }
    }
}
