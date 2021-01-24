using System;
using System.IO;

namespace _01._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readFile = new StreamReader("../../../input.txt"))
            {
                int counter = 0;
                string line = readFile.ReadLine();

                using (StreamWriter writeFile = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 == 1)
                        {
                            writeFile.WriteLine(line);
                        }
                        line = readFile.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
