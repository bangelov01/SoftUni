﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts.Add(number, 1);
                }
            }

            foreach (var item in counts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}