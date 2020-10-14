using System;

namespace _02.Character_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                Console.WriteLine(letter);
            }
        }
    }
}
