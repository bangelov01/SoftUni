using System;
using System.Collections.Generic;

namespace _06._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] elementsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < elementsArr.Length; j++)
                {
                    if(!elements.Contains(elementsArr[j]))
                    {
                        elements.Add(elementsArr[j]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
