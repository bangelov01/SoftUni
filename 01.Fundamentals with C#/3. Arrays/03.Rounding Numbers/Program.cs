using System;
using System.Linq;

namespace _03.Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrRealNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            for (int i = 0; i < arrRealNums.Length; i++)
            {
                if (arrRealNums[i] == -0)
                {
                    arrRealNums[i] = 0;
                }
                Console.WriteLine($"{arrRealNums[i]} => {(int)Math.Round(arrRealNums[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
