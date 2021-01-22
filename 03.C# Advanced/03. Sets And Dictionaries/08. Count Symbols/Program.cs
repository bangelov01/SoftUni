using System;
using System.Collections.Generic;

namespace _08._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SortedDictionary<char, int> countChars = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!countChars.ContainsKey(text[i]))
                {
                    countChars.Add(text[i], 0);
                }
                countChars[text[i]]++;
            }

            foreach (var item in countChars)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
