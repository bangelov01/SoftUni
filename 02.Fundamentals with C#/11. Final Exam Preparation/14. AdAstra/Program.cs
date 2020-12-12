using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _14._AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"(#|\|)(?<item>[A-Za-z ]+)\1(?<date>\d+\/\d+\/\d{2})\1(?<calories>\d+)\1";

            int calSum = 0;

            MatchCollection matches = Regex.Matches(input, regex);

            foreach (Match product in matches)
            {
                int calories = int.Parse(product.Groups["calories"].Value);

                calSum += calories;
            }
            int days = calSum/2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["item"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}
