using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToArray();

            Dictionary<char, int> charDict = new Dictionary<char, int>();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != ' ')
                {
                    if (!charDict.ContainsKey(chars[i]))
                    {
                        charDict.Add(chars[i], 0);
                    }
                    charDict[chars[i]]++;
                }
            }

            foreach (var item in charDict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
