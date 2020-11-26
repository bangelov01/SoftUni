using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _22._ListManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;

            int blackListCount = 0;
            int lostNames = 0;

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] commndArr = command.Split();

                string action = commndArr[0];

                if (action == "Blacklist")
                {
                    string name = commndArr[1];

                    if (friends.Exists(x => x == name))
                    {
                        int index = friends.IndexOf(name);
                        friends[index] = "Blacklisted";
                        blackListCount++;
                        Console.WriteLine($"{name} was blacklisted.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }
                else if (action == "Error")
                {
                    int index = int.Parse(commndArr[1]);

                    if (friends[index] != "Blacklisted" && friends[index] != "Lost")
                    {
                        string saveName = friends[index];
                        friends[index] = "Lost";
                        lostNames++;
                        Console.WriteLine($"{saveName} was lost due to an error.");
                    }
                }
                else if (action == "Change")
                {
                    int index = int.Parse(commndArr[1]);
                    string newName = commndArr[2];

                    if (index >= 0 && index <= friends.Count - 1)
                    {
                        string currentName = friends[index];
                        friends[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }
            }

            Console.WriteLine($"Blacklisted names: {blackListCount}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(" ", friends));
        }
    }
}
