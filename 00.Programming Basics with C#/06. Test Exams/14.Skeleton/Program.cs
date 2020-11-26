using System;

namespace _14.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double minutes = double.Parse(Console.ReadLine());
            double seconds = double.Parse(Console.ReadLine());
            double lengthTrack = double.Parse(Console.ReadLine());
            double secondsFor100Meters = double.Parse(Console.ReadLine());

            
            double raceSeconds = (minutes * 60) + seconds;
            double timeReduce = lengthTrack / 120;
            double totalTimeReduce = timeReduce * 2.5;

            double time = (lengthTrack / 100) * secondsFor100Meters - totalTimeReduce;

            if (raceSeconds >= time)
            {

                Console.WriteLine($"Marin Bangiev won an Olympic quota!\r\nHis time is {time:f3}.");
            }
            else
            {
                time -= raceSeconds;
                Console.WriteLine($"No, Marin failed! He was {time:f3} second slower.");
            }
        }
    }
}
