using System;
using System.Linq;

namespace _13.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int firstElement = array[0];
                int[] holderArray = new int[array.Length];

                for (int j = 1; j < array.Length; j++)
                {
                    holderArray[j - 1] = array[j];
                }

                holderArray[holderArray.Length - 1] = firstElement;
                array = holderArray.ToArray();
            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
