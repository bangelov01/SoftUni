using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericSwapMethodStrings
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int boxQuantity = int.Parse(Console.ReadLine());

            List<Box<int>> stringsList = new List<Box<int>>();

            for (int i = 0; i < boxQuantity; i++)
            {
                int name = int.Parse(Console.ReadLine());
                Box<int> newBox = new Box<int>(name);
                stringsList.Add(newBox);
            }

            int[] indexes = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            Swap(stringsList, indexOne, indexTwo);

            stringsList.ForEach(x => Console.WriteLine(x));
        }

        public static void Swap<T> (List<T> list, int indexOne, int indexTwo)
        {
            var holder = list[indexTwo];
            list[indexTwo] = list[indexOne];
            list[indexOne] = holder;
        }
    }
}
