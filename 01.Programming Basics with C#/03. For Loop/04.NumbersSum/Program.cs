using System;

namespace _04._Numbers_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int i = 1; i <= n ; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                sum += n2;
            }
            Console.WriteLine(sum);


        }
    }
}
