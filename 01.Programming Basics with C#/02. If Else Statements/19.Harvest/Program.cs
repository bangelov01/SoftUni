using System;

namespace _19.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int squareMeters = int.Parse(Console.ReadLine());
            double grapesForSqMeter = double.Parse(Console.ReadLine());
            int neededLitresWine = int.Parse(Console.ReadLine());
            int numberOfWorkers = int.Parse(Console.ReadLine());

            double totalGrapes = squareMeters * grapesForSqMeter;
            double totalWine = ((totalGrapes * 40) / 100) / 2.5;

            if (totalWine < neededLitresWine)
            {
                double neededWine = neededLitresWine - totalWine;

                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededWine)} liters wine needed.");
            }
            else
            {
                double leftWine = totalWine - neededLitresWine;
                double perPerson = leftWine / numberOfWorkers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(leftWine)} liters left -> {Math.Ceiling(perPerson)} liters per person.");
            }
        }
    }
}
