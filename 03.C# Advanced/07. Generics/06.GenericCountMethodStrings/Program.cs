using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int cycles = int.Parse(Console.ReadLine());

            List<string> newList = new List<string>();

            for (int i = 0; i < cycles; i++)
            {
                string input = Console.ReadLine();
                newList.Add(input);
            }

            string valueToCompare = Console.ReadLine();

            Console.WriteLine(Compare(newList,valueToCompare));
        }

        public static int Compare<T> (List<T> list, T element) where T : IComparable
        {
            int largerElementsCount = 0;

            foreach (var item in list)
            {
                int isBGreater = item.CompareTo(element);

                if (isBGreater > 0)
                {
                    largerElementsCount++;
                }
            }

            return largerElementsCount;
        }
    }
}
