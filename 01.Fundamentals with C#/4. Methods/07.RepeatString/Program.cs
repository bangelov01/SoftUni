using System;
using System.Text;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RepeatString(Console.ReadLine(), int.Parse(Console.ReadLine())));
        }

        static string RepeatString (string input, int cycles)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= cycles; i++)
            {
                result.Append(input);
            }
            return result.ToString();
        }
    }
}
