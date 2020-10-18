using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14._AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            items.Reverse();

            List<string> result = new List<string>();

            foreach (string currentItem in items)
            {
                string[] numbers = currentItem.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (string toAdd in numbers)
                {
                    result.Add(toAdd);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
