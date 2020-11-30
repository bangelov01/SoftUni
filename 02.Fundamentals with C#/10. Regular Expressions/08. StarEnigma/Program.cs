using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _08._StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            string regexDecrypt = @"[^SsTtAaRr]+";

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            while (numberOfMessages > 0)
            {
                string message = Console.ReadLine();

                string decryptKey = Regex.Replace(message, regexDecrypt, string.Empty);

                int keyValue = decryptKey.Length;

                StringBuilder decryptOut = new StringBuilder();

                for (int i = 0; i < message.Length; i++)
                {
                    int newChar = message[i] - keyValue;
                    decryptOut.Append((char)newChar);
                }
                ;
                string decryptedReg = @"@(?<planet>[A-Za-z]+)([^@\-!:>])*:(?<population>[\d]+)([^@\-!:>])*!(?<attype>[AD])!([^@\-!:>])*->(?<scount>\d+)";

                Match decrMessage = Regex.Match(decryptOut.ToString(), decryptedReg);

                if (decrMessage.Success)
                {
                    string planet = decrMessage.Groups["planet"].Value;
                    char attackType = char.Parse(decrMessage.Groups["attype"].Value);

                    if (attackType == 'A')
                    {
                        attackedPlanets.Add(planet);
                    }
                    else
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
                numberOfMessages--;
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
