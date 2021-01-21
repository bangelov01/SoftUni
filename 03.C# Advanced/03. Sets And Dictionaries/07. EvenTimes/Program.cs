using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numsCount = int.Parse(Console.ReadLine());

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = 0; i < numsCount; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(num))
                {
                    dict.Add(num, new List<int>() {num});
                }
                else
                {
                    dict[num].Add(num);
                }
            }

            foreach (var num in dict)
            {
                if (num.Value.Count % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
