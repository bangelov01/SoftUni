using System;

namespace _10.USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double usd = double.Parse(Console.ReadLine());
            double bgn = usd * 1.79549;

            Console.WriteLine(String.Format("{0:0.##}", bgn));
        }
    }
}
