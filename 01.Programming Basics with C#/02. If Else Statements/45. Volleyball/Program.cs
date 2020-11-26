using System;

namespace _45._Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            double numberOfHolidaysInYearNotSatOrSun = int.Parse(Console.ReadLine());
            double numberOfWeekendsTravelHome = int.Parse(Console.ReadLine());
            
            double numberOfWeekendsInSofia = 48 - numberOfWeekendsTravelHome;
            double saturdayPlaysInSofia = numberOfWeekendsInSofia * 3 / 4;
            double playsInSofiaHolidays = numberOfHolidaysInYearNotSatOrSun * 2 / 3;
            double totalGamesWeekendAndHolidayEverywhere = saturdayPlaysInSofia + numberOfWeekendsTravelHome + playsInSofiaHolidays;

            if (yearType == "leap")
            {
                double bonus = totalGamesWeekendAndHolidayEverywhere * 0.15;
                totalGamesWeekendAndHolidayEverywhere += bonus;
            }

            Console.WriteLine(Math.Floor(totalGamesWeekendAndHolidayEverywhere));

        }
    }
}
