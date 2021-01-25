using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                Regex pattern = new Regex(@"[\!\,\.\?\-]");
                List<string> reversedWords = new List<string>();
                int counter = 0;

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        string newLine = pattern.Replace(line, "@");
                        reversedWords = newLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();
                        StringBuilder finalLine = new StringBuilder();
                        foreach (var word in reversedWords)
                        {
                            finalLine.Append(word + " ");
                        }
                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(finalLine.ToString().TrimEnd());
                        }
                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
