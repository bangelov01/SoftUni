using System;

namespace _20.Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            double screenTime = double.Parse(Console.ReadLine());
            double screenAmount = double.Parse(Console.ReadLine());
            double screenRuntime = double.Parse(Console.ReadLine());

            double prep = screenTime * 0.15;

            double captureTime = screenAmount * screenRuntime;
            captureTime += prep;

            if (captureTime <= screenTime)
            {
                screenTime -= captureTime;
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(screenTime)} minutes left!");
            }
            else
            {
                captureTime -= screenTime;
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(captureTime)} minutes."
);
            }
        }
    }
}
