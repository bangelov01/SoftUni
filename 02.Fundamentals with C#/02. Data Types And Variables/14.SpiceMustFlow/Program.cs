using System;

namespace _29.Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            uint startingYield = uint.Parse(Console.ReadLine());
            uint sum = 0;
            int daysCount = 0;

            while (startingYield >= 100)
            {
                uint save = startingYield;
                save -= 26;
                sum += save;
                startingYield -= 10;
                daysCount++;
            }
            if (sum >= 26)
            {
                sum -= 26;
            }
            Console.WriteLine(daysCount);
            Console.WriteLine(sum);
        }
    }
}
