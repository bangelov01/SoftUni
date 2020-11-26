using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string reg = @"\+[359]{3}(\s|-)[2]{1}\1[0-9]{3}\1\b[0-9]{4}\b";

            string text = Console.ReadLine();

            MatchCollection output = Regex.Matches(text, reg);

            string[] matches = output.Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
