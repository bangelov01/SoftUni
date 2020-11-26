using System;
using System.Text.RegularExpressions;

namespace _01._MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regEx = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            string input = Console.ReadLine();

            MatchCollection output = Regex.Matches(input, regEx);

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
