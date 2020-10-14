using System;
using System.Linq;

namespace _13.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            Console.WriteLine(ReturnVowelsIn(text));
        }

        static int ReturnVowelsIn(string text)
        {
            int count = 0;
            char[] chars = new char[] { 'a', 'i', 'o', 'e', 'u' };
            for (int i = 0; i < text.Length; i++)
            {
                if (chars.Contains(text[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
