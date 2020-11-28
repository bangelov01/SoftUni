using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> scores = new Dictionary<string, int>();

            foreach (var item in participants)
            {
                scores.Add(item, 0);
            }

            string input = string.Empty;

            string nameReg = @"[\W\d]";

            string scoreReg = @"[\WA-Za-z]";

            while ((input = Console.ReadLine()) != "end of race")
            {

                string name = Regex.Replace(input,nameReg,"");
                string score = Regex.Replace(input,scoreReg,"");

                if (scores.ContainsKey(name))
                {
                    foreach (var item in score)
                    {
                        scores[name] += int.Parse(item.ToString());
                    }
                }
            }

            int place = 1;

            foreach (var item in scores.OrderByDescending(x => x.Value))
            {
                string suffix = place == 1 ? "st" : place == 2 ? "nd" : "rd";

                Console.WriteLine($"{place++}{suffix} place: {item.Key}");

                if (place == 4)
                {
                    break;
                }
            }
        }
    }
}
