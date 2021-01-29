using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _13._CustomComparator
{
    class Program
    {
        public class NumberComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return x.CompareTo(y);
                }
            }
        }
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            NumberComparer comparer = new NumberComparer();

            nums.Sort(comparer);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
