using System;

namespace _05._Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberBreads = double.Parse(Console.ReadLine());
            double sumUsedFlour = 0;
            double sumUsedSugar = 0;
            double maxSugar = double.MinValue;
            double maxFlour = double.MinValue;

            for (double i = 1; i <= numberBreads ; i++)
            {
                double usedSugar = double.Parse(Console.ReadLine());
                if (usedSugar > maxSugar) maxSugar = usedSugar;
                double usedFlour = double.Parse(Console.ReadLine());
                if (usedFlour > maxFlour) maxFlour = usedFlour;
                sumUsedSugar += usedSugar;
                sumUsedFlour += usedFlour;

            }
            double numberPacksSugar = Math.Ceiling(sumUsedSugar / 950);
            double numberPacksFlour = Math.Ceiling(sumUsedFlour / 750);

            Console.WriteLine($"Sugar: {numberPacksSugar}\r\nFlour: {numberPacksFlour}\r\nMax used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");
        }
    }
}
