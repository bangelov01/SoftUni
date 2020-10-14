using System;
using System.Linq;

namespace _08.Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            while (array.Length > 1)
            {
                int[] arrayPlus = new int[array.Length - 1];

                for (int i = 0; i < arrayPlus.Length; i++)
                {
                    arrayPlus[i] = array[i] + array[i + 1];
                }
                array = arrayPlus;
            }
            Console.WriteLine(array[0]);

        }
    }
}
