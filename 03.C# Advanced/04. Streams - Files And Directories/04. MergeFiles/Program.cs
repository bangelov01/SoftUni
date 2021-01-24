using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04._MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileOneText = File.ReadAllText("../../../FileOne.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            string[] fileTwoText = File.ReadAllText("../../../FileTwo.txt").Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            List<string> combined = new List<string>();

            for (int i = 0; i < fileOneText.Length; i++)
            {
                combined.Add(fileOneText[i]);
            }
            for (int j = 0; j < fileTwoText.Length; j++)
            {
                combined.Add(fileTwoText[j]);
            }


            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var item in combined.OrderBy(x => x))
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
