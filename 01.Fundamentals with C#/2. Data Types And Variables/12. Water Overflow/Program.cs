using System;

namespace _27._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            byte n = byte.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                short litres = short.Parse(Console.ReadLine());
                if (litres > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                else
                {
                    sum += litres;
                    capacity -= litres;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
