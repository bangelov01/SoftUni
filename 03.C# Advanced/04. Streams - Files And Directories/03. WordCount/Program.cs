using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            string[] words = File.ReadAllText("../../../words.txt").Split();

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] currentWords = line.ToLower().Split(new[] {' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        foreach (var item in currentWords)
                        {
                            if (word == item)
                            {
                                if (!wordCount.ContainsKey(item))
                                {
                                    wordCount.Add(item, 0);
                                }
                                wordCount[item]++;
                            }
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var item in wordCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
