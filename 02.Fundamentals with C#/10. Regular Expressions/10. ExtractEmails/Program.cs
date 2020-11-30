using System;
using System.Text.RegularExpressions;

namespace _10._ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string regex = @"(^|(?<=\s))[A-Za-z0-9]+[.,-_]?[A-Za-z0-9-]+\@([A-Za-z]+([._][A-Za-z]+)+)(\b|(?=\s))";

            MatchCollection matches = Regex.Matches(text, regex);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
