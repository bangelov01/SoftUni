using System;
using System.IO;

namespace _06._LineNumbersTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialLines = File.ReadAllLines("../../../text.txt");
            int letterCount = 0;
            int punctCount = 0;

            for (int i = 0; i < initialLines.Length; i++)
            {
                for (int j = 0; j < initialLines[i].Length; j++)
                {
                    if (!char.IsWhiteSpace(initialLines[i][j]) && !char.IsDigit(initialLines[i][j]))
                    {
                        if (char.IsLetter(initialLines[i][j]))
                        {
                            letterCount++;
                        }
                        else
                        {
                            punctCount++;
                        }
                    }
                }

                initialLines[i] = $"Line {i + 1}: {initialLines[i]} ({letterCount})({punctCount})";
                letterCount = 0;
                punctCount = 0;
            }

            File.WriteAllLines("../../../output.txt", initialLines);
        }
    }
}
