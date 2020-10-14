using System;

namespace _12._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            
            double totalNumberCount = 0;
            double numCount1 = 0;
            double numCount2 = 0;
            double numCount3 = 0;
            double numCount4 = 0;
            double numCount5 = 0;

            for (double i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                totalNumberCount++;
                if (num < 200) numCount1++;
                if (num >= 200 && num <= 399) numCount2++;
                if (num > 399 && num <= 599) numCount3++;
                if (num > 599 && num <= 799) numCount4++;
                if (num >= 800) numCount5++;

            }

            Console.WriteLine($"{numCount1 / totalNumberCount * 100:f2}%");
            Console.WriteLine($"{numCount2 / totalNumberCount * 100:f2}%"); 
            Console.WriteLine($"{numCount3 / totalNumberCount * 100:f2}%"); 
            Console.WriteLine($"{numCount4 / totalNumberCount * 100:f2}%"); 
            Console.WriteLine($"{numCount5 / totalNumberCount * 100:f2}%");



        }
    }
}
