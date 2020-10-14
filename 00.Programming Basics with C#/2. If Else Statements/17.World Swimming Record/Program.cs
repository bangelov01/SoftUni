using System;

namespace _17.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeForOneMeterSwin = double.Parse(Console.ReadLine());

            double secondsForDistance = distanceInMeters * timeForOneMeterSwin;
            double addTwelveSecCalc = Math.Floor(distanceInMeters/15) * 12.5;
            double totalTime = secondsForDistance + addTwelveSecCalc;

            if (totalTime < recordInSeconds)
            { 
                
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            
            else
            {
                
                double needTime = totalTime - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {needTime:f2} seconds slower.");
            }
        }
    }
}
