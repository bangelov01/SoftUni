using System;
using System.Linq;

namespace _16._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            // 2 1 1 2 3 3 2 2 2 1
            int length = 1;
            int currentLength = 1;
            int sequenceDigit = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    currentLength++;
                }
                else
                {
                    currentLength = 1;
                }
                if (currentLength > length)
                {
                    length = currentLength;
                    sequenceDigit = array[i];
                }
            }

            int[] finalArray = new int[length];

            for (int j = 0; j < finalArray.Length; j++)
            {
                finalArray[j] = sequenceDigit;
            }
            Console.WriteLine(string.Join(" ", finalArray));
        }
    }
}
