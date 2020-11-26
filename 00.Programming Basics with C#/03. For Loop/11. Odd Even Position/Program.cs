using System;

namespace _11._Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double evenMaxValue = -1000000000.0;
            double evenMinValue = 1000000000.0;
            double oddMaxValue = -1000000000.0;
            double oddMinValue = 1000000000.0;
            double evenSum = 0;
            double oddSum = 0;
            
            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                        if (num > evenMaxValue) evenMaxValue = num;
                        if (num < evenMinValue) evenMinValue = num;
                }
                else
                {
                    oddSum += num;
                        if (num > oddMaxValue) oddMaxValue = num;
                        if (num < oddMinValue) oddMinValue = num;
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddMinValue == 1000000000.0)
            {
                Console.WriteLine("OddMin=No,");
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMinValue:f2},");
                Console.WriteLine($"OddMax={oddMaxValue:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenMinValue == 1000000000.0)
            {
                Console.WriteLine("EvenMin=No,");
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMinValue:f2},");
                Console.WriteLine($"EvenMax={evenMaxValue:f2}");
            }
            
        }
    }
}
