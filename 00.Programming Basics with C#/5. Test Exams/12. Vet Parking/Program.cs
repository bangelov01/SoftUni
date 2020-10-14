using System;
using System.Xml.Linq;

namespace _12._Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            double numDays = double.Parse(Console.ReadLine());
            double numHours = double.Parse(Console.ReadLine());
            double sum = 0;
            double store = 0;

            for (int i = 1; i <= numDays; i++)
            {
                for (int j = 1; j <= numHours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        sum += 2.50;
                    }
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        sum += 1;
                    }
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        sum += 1.25;
                    }
                    if (i % 2 != 0 && j % 2 != 0)
                    {
                        sum += 1;
                    }
                }
                Console.WriteLine($"Day: {i} - {sum:f2} leva");
                store += sum;
                sum = 0;
            }
            Console.WriteLine($"Total: {store:f2} leva");
        }
    }
}
