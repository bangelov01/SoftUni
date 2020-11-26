using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> sideDict = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] inputArr = input.Split(" | ");

                    string side = inputArr[0];
                    string student = inputArr[1];

                    if (!sideDict.ContainsKey(side))
                    {
                        sideDict.Add(side, new List<string>());
                    }
                    if (!sideDict.Values.Any(x => x.Contains(student)))
                    {
                        sideDict[side].Add(student);
                    }
                }
                else if (input.Contains(" -> "))
                {
                    string[] inputArr = input.Split(" -> ");

                    string student = inputArr[0];
                    string side = inputArr[1];

                    if (!sideDict.Any(x => x.Value.Contains(student)))
                    {
                        if (!sideDict.ContainsKey(side))
                        {
                            sideDict.Add(side, new List<string>());
                        }
                        sideDict[side].Add(student);
                        Console.WriteLine($"{student} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var item in sideDict)
                        {
                            if (item.Value.Contains(student))
                            {
                                item.Value.Remove(student);
                            }
                        }
                        if (!sideDict.ContainsKey(side))
                        {
                            sideDict.Add(side, new List<string>());
                        }
                        sideDict[side].Add(student);
                        Console.WriteLine($"{student} joins the {side} side!");
                    }
                }
            }

            foreach (var side in sideDict.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }          
        }
    }
}
