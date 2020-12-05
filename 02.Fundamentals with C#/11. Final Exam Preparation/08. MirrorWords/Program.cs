using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08._MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"([@]{1}|[#]{1})(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

            List<string> mirroredWords = new List<string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!\r\nNo mirror words!");
                Environment.Exit(0);
            }

            Console.WriteLine($"{matches.Count} word pairs found!");

            foreach (Match item in matches)
            {
                string wordOne = item.Groups["firstWord"].Value;
                string wordTwo = item.Groups["secondWord"].Value;

                StringBuilder reverseWord = new StringBuilder();


                for (int i = wordTwo.Length - 1; i >= 0; i--)
                {
                    reverseWord.Append(wordTwo[i]);
                }

                if (wordOne == reverseWord.ToString())
                {
                    string toAdd = $"{wordOne} <=> {wordTwo}";
                    mirroredWords.Add(toAdd);
                }
            }

            if (mirroredWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirroredWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
