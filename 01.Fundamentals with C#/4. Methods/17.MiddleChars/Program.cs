using System;
using System.Text;

namespace _17.MiddleChars
{
    class Program
    {
        public static StringBuilder StringBuilder { get; private set; }

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(ReturnMiddleChar(text));
        }

        static string ReturnMiddleChar(string text)
        {
            if (text.Length % 2 == 1)
            {
                int a = text.Length / 2;
                return Convert.ToString(text[a]);
            }
            else
            {
                StringBuilder concatText = new StringBuilder();
                int a = text[(text.Length / 2) - 1];
                int b = text[text.Length / 2];

                concatText.Append((char)a);
                concatText.Append((char)b);

                return concatText.ToString();
            }
        }
    }
}
