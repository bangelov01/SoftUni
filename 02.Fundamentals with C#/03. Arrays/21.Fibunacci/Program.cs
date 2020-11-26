using System;

namespace _21.Fibunacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long fibonacciNumber = long.Parse(Console.ReadLine());
            if (fibonacciNumber <= 0)
            {
                Console.WriteLine(0);
                return;
            }
            else if (fibonacciNumber == 1)
            {
                Console.WriteLine(1);
                return;
            }
            else if (fibonacciNumber == 2)
            {
                Console.WriteLine(1);
                return;
            }
            long[] array = new long[fibonacciNumber];
            array[0] = 1;
            array[1] = 1;
            long holder = 0;

            for (long i = 2; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2];
                holder = array[i];
            }
            Console.WriteLine($"{holder}");
        }
    }
}
