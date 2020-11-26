using System;
using System.Text.RegularExpressions;

namespace _03._MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?<day>[0-2][0-9]|3[0-1])(.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";

            string input = Console.ReadLine();

            MatchCollection output = Regex.Matches(input, regex);

            foreach (Match date in output)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
