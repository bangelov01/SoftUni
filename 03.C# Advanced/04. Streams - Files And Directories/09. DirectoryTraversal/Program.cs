using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09._DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string desiredPath = "../../../obj/";
            string[] files = Directory.GetFiles(desiredPath);
            Dictionary<string, Dictionary<string, double>> fileDict = new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                string name = info.Name;
                double size = info.Length;

                if (!fileDict.ContainsKey(extension))
                {
                    fileDict.Add(extension, new Dictionary<string, double>());
                }
                if (!fileDict[extension].ContainsKey(name))
                {
                    fileDict[extension].Add(name, size);
                }
            }

            foreach (var extension in fileDict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(extension.Key);

                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    Console.WriteLine($"--{file.Key}{extension.Key} - {Math.Round(file.Value, 3)}kb");
                }
            }
        }
    }
}
