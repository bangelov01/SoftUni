using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNum = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothesDict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesNum; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                string color = input[0];
                string[] clothes = input.Skip(1).ToArray();

                if (!clothesDict.ContainsKey(color))
                {
                    clothesDict.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!clothesDict[color].ContainsKey(clothes[j]))
                    {
                        clothesDict[color].Add(clothes[j], 1);
                    }
                    else
                    {
                        clothesDict[color][clothes[j]]++;
                    }
                }
            }

            string[] foundItem = Console.ReadLine().Split();

            foreach (var colour in clothesDict)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var clothing in clothesDict[colour.Key])
                {
                    if (foundItem[0] == colour.Key && foundItem[1] == clothing.Key)
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");

                    }
                    else
                    {
                        Console.WriteLine($"* {clothing.Key} - {clothing.Value}");

                    }
                }
            }
        }
    }
}
