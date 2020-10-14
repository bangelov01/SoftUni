using System;
using System.Linq;

namespace _22._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArray = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            int[] firstRow = new int[initialArray.Length / 2];
            int[] secondRw = new int[initialArray.Length / 2];
            int[] FinalArray = new int[initialArray.Length / 2];

            int counter = 0;

            for (int i = initialArray.Length / 4 - 1; i >= 0; i--)
            {
                while (counter >= 0)
                {
                    firstRow[counter] = initialArray[i];
                    break;
                }
                counter++;
            }

            for (int j = initialArray.Length - 1; j >= initialArray.Length / 4 + initialArray.Length / 2; j--)
            {
                while (counter >= 0)
                {
                    firstRow[counter] = initialArray[j];
                    break;
                }
                counter++;
            }
            counter = 0;
            for (int k = initialArray.Length / 4; k < initialArray.Length / 4 + initialArray.Length / 2; k++)
            {
                while (counter >= 0)
                {
                    secondRw[counter] = initialArray[k];
                    break;
                }
                counter++;
            }

            for (int i = 0; i < FinalArray.Length; i++)
            {
                FinalArray[i] = firstRow[i] + secondRw[i];
            }
            Console.WriteLine(string.Join(' ', FinalArray));
        }
    }
}
