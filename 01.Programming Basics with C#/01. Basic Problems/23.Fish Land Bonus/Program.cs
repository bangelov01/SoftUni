using System;

namespace _23.Fish_Land_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double mackarelPriceKg = double.Parse(Console.ReadLine());
            double spratPriceKg = double.Parse(Console.ReadLine());
            double bonitoKg = double.Parse(Console.ReadLine());
            double scadKg = double.Parse(Console.ReadLine());
            int shellsKg = int.Parse(Console.ReadLine());

            double shellsPriceKg = 7.50;
            double bonitoPriceKg = mackarelPriceKg + (mackarelPriceKg*0.60);
            double scadPriceKg = spratPriceKg + (spratPriceKg * 0.80);

            double shellsWholePrice = (shellsKg * shellsPriceKg);
            double bonitoWholePrice = (bonitoKg * bonitoPriceKg);
            double scadWholePrice = (scadKg * scadPriceKg);

            float sumTotal = (float)(shellsWholePrice + bonitoWholePrice + scadWholePrice);

            Console.WriteLine($"{sumTotal:f2}");



        }
    }
}
