using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listOfWords = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Random rnd = new Random();

            for (int i = 0; i < listOfWords.Count; i++)
            {
                int index = rnd.Next(0, listOfWords.Count);

                string holder = listOfWords[index];
                listOfWords[index] = listOfWords[i];
                listOfWords[i] = holder;
            }

            foreach (string item in listOfWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
