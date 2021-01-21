using System;
using System.Collections.Generic;

namespace _04._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int cycles = int.Parse(Console.ReadLine());

            HashSet<string> usernameSet = new HashSet<string>();

            for (int i = 0; i < cycles; i++)
            {
                string username = Console.ReadLine();

                if (!usernameSet.Contains(username))
                {
                    usernameSet.Add(username);
                }
            }

            foreach (var username in usernameSet)
            {
                Console.WriteLine(username);
            }
        }
    }
}
