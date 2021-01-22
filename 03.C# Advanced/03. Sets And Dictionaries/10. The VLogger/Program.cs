using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_VLogger
{
    class Program
    {
        class VloggerInfo
        {
            public VloggerInfo(SortedSet<string> followers, HashSet<string> following)
            {
                Followers = followers;
                Following = following;
            }
            public SortedSet<string> Followers { get; set; }
            public HashSet<string> Following { get; set; }

        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string,VloggerInfo> vloggersCollection = new Dictionary<string, VloggerInfo>();

            while (input[0] != "Statistics")
            {
                string vloggerName = input[0];
                string action = input[1];

                if (action == "joined")

                {
                    if (!vloggersCollection.ContainsKey(vloggerName))
                    {
                        vloggersCollection.Add(vloggerName, new VloggerInfo(new SortedSet<string>(), new HashSet<string>()));
                    }
                }
                else if (action == "followed")
                {
                    string secondVloggerName = input[2];

                    if (vloggersCollection.ContainsKey(vloggerName) && 
                        vloggersCollection.ContainsKey(secondVloggerName) && 
                        vloggerName != secondVloggerName && 
                        !vloggersCollection[vloggerName].Following.Contains(secondVloggerName))
                    {
                        vloggersCollection[vloggerName].Following.Add(secondVloggerName);
                        vloggersCollection[secondVloggerName].Followers.Add(vloggerName);
                    }

                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int count = 1;

            Console.WriteLine($"The V-Logger has a total of {vloggersCollection.Count} vloggers in its logs.");

            foreach (var vlogger in vloggersCollection.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Following.Count))
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");

                if (count == 1)
                {
                    foreach (var followers in vloggersCollection[vlogger.Key].Followers)
                    {
                        Console.WriteLine($"*  {followers}");
                    }
                }
                count++;
            }
        }
    }
}
