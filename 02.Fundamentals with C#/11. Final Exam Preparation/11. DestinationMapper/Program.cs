using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _11._DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"([=]|[\/])([A-Z][A-Za-z]{2,})\1";

            List<string> destinations = new List<string>();

            int travelPoints = 0;

            MatchCollection matches = Regex.Matches(input, regex);


            foreach (Match destination in matches)
            {
                string trimmedStr = destination.Value.Trim(new char[] { '=', '/' });

                travelPoints += trimmedStr.Length;

                destinations.Add(trimmedStr);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}\r\n" +
                $"Travel Points: {travelPoints}");
        }
    }
}
