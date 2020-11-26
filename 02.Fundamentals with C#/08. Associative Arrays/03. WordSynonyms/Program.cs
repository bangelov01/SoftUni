using System;
using System.Collections.Generic;

namespace _03._WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (words.ContainsKey(word))
                {
                    words[word].Add(synonym);
                }
                else
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }

            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
