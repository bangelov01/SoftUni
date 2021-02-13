using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> stoneNums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Lake newLake = new Lake(stoneNums);

            Console.WriteLine(string.Join(", ",newLake));
        }
    }
}
