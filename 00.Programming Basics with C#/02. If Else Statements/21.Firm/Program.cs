using System;

namespace _21.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededHours = double.Parse(Console.ReadLine());
            double availableDays = double.Parse(Console.ReadLine());
            double overtimeWorkers = double.Parse(Console.ReadLine());

            double daysForTraining = (availableDays * 0.90)*8;
            double overtimeHours = overtimeWorkers * (availableDays * 2);
            double totalHours = Math.Floor(daysForTraining+overtimeHours);

            if (totalHours >= neededHours)
            {
                totalHours -= neededHours;

                Console.WriteLine($"Yes!{totalHours} hours left.");
            }
            else
            {
                double plusHours = neededHours - totalHours;

                Console.WriteLine($"Not enough time!{plusHours} hours needed.");
            }
        }
    }
}
