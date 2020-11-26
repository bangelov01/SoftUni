using System;

namespace _07._CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            string longWord = input[0];
            string shortWord = input[1];

            if (shortWord.Length > longWord.Length)
            {
                longWord = input[1];
                shortWord = input[0];
            }

            Console.WriteLine(GetCharSum(shortWord, longWord));
        }

        static int GetCharSum (string shortWord, string longWord)
        {
            int sum = 0;
            int saveI = 0;

            string manipulatedLong = string.Empty;

            for (int i = 0; i < shortWord.Length; i++)
            {
                int multiply = shortWord[i] * longWord[i];
                sum += multiply;
                saveI++;
            }

            for (int i = saveI; i < longWord.Length; i++)
            {
                sum += longWord[i];
            }

            return sum;
        }
    }
}
