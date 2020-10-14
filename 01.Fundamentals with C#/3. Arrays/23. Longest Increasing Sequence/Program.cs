using System;
using System.Linq;

namespace _23._Longest_Increasing_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            int length = 0;
            int digitHolder = 0;
            int[] finalArray = new int[] { };

            for (int i = 0; i < array.Length; i++)
            {
                if (array.Length <= 1)
                {
                    Console.WriteLine($"{array[i]}");
                    return;
                }
                else
                {
                    if (digitHolder )
                    {

                    }
                    digitHolder = array[i];
                }
            }
        }
    }
}
