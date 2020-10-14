using System;
using System.Linq;

namespace _12.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] finalArrayOne = new int[n];
            int[] finalArrayTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] innerArray = Console.ReadLine().Split()
                    .Select(int.Parse)
                    .ToArray();

                 if (i % 2 == 0)
                 {
                     finalArrayOne[i] = innerArray[0];
                     finalArrayTwo[i] = innerArray[1];
                 }
                 else
                 {
                     finalArrayOne[i] = innerArray[1];
                     finalArrayTwo[i] = innerArray[0];
                 }
            }
            Console.WriteLine(string.Join(" ", finalArrayOne));
            Console.WriteLine(string.Join(" ", finalArrayTwo));
        }
    }
}
