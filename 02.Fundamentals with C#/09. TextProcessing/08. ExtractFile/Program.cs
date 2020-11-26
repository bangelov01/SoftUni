using System;

namespace _08._ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split(@"\");

            string[] fileExt = path[path.Length - 1].Split(".");

            Console.WriteLine($"File name: {fileExt[0]}");
            Console.WriteLine($"File extension: {fileExt[1]}");
        }
    }
}
