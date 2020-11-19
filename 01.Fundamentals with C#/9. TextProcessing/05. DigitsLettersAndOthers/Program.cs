using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others = new StringBuilder();

            //List<char> digits = new List<char>();

            //List<char> letters = new List<char>();

            //List<char> others = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    //digits.Add(input[i]);
                    digits.Append(input[i]);
                }
                else if (char.IsLetter(input[i]))
                {
                    //letters.Add(input[i]);
                    letters.Append(input[i]);
                }
                else
                {
                    //others.Add(input[i]);
                    others.Append(input[i]);
                }
            }

            //Console.WriteLine($"{string.Join("", digits)}\r\n" +
            //    $"{string.Join("", letters)}\r\n" +
            //    $"{string.Join("", others)}");

            Console.WriteLine($"{digits}\r\n" +
                $"{letters}\r\n" +
                $"{others}");
        }
    }
}
