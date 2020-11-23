using System;
using System.Text;

namespace _11._ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            char saveChar = input[0];

            output.Append(saveChar);

            for (int i = 1; i <= input.Length - 1; i++)
            {
                if (saveChar != input[i])
                {
                    saveChar = input[i];
                    output.Append(saveChar);
                }
            }
            Console.WriteLine(output);
        }
    }
}
