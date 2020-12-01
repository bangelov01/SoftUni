using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string emojiPattern = @"([:]{2}|[*]{2})([A-Z][a-z]{2,})\1";

            string digitPattern = @"[\d]";

            List<string> coolEmojis = new List<string>();

            MatchCollection emojis = Regex.Matches(input, emojiPattern);
            MatchCollection digits = Regex.Matches(input, digitPattern);


            BigInteger coolFactor = new BigInteger();
            coolFactor = 1;

            foreach (Match digit in digits)
            {
                coolFactor *= int.Parse(digit.Value);
            }

            foreach (Match emoji in emojis)
            {
               int coolness = emoji.Value.Where(x => char.IsLetter(x)).Sum(x => x);

                if (coolness >= coolFactor)
                {
                    coolEmojis.Add(emoji.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolFactor}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            if (coolEmojis.Count != 0)
            {
                foreach (var item in coolEmojis)
                {
                    Console.WriteLine($"{item}");
                }
            }
        }
    }
}
