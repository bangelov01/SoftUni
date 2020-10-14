using System;
using System.Linq;

namespace _10._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrN = new int[n];
            int sum = 0;

            for (int i = 0; i < arrN.Length; i++)
            {
                arrN[i] = int.Parse(Console.ReadLine());
                sum += arrN[i];

            }
            Console.WriteLine(string.Join(" ", arrN));
            Console.WriteLine(sum);
        }
    }
}
