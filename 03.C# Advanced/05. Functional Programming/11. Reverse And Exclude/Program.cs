using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .Reverse()
                                           .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<int,int, bool> condition = (num,divider) => num % divider != 0;

            nums = nums.Where(n => condition(n,divider)).ToList();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
