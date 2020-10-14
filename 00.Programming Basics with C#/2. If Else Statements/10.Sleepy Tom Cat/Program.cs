using System;

namespace _10.Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOff = int.Parse(Console.ReadLine());
            
            int workDays = 365 - daysOff;
            int realPlayTime = (workDays * 63) + (daysOff * 127);
            int normDifference = 30000 - realPlayTime;
            int toHourCalc = normDifference / 60;
            int minutesLeft = normDifference % 60;

            if (30000 >= realPlayTime )
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{toHourCalc} hours and {minutesLeft} minutes less for play");
            }
            else
            {               

                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{toHourCalc*-1} hours and {minutesLeft*-1} minutes more for play");
            }



        }
    }
}
