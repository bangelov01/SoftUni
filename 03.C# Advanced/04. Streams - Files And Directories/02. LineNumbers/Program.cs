using System;
using System.IO;

namespace _02._LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader read = new StreamReader("../../../input.txt"))
            {
                string line = read.ReadLine();
                int counter = 1;

                using (StreamWriter write = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        write.WriteLine($"{counter}. {line}");
                        line = read.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}
