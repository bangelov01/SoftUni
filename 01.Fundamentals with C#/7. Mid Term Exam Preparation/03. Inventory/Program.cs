using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> materials = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] commandArr = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArr[0];
                string item = commandArr[1];

                if (action == "Collect")
                {
                    if (!materials.Exists(x => x == item))
                    {
                        materials.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    if (materials.Exists(x => x == item))
                    {
                        materials.Remove(item);
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] splitItem = item.Split(":",StringSplitOptions.RemoveEmptyEntries);

                    string oldItem = splitItem[0];
                    string newItem = splitItem[1];

                    if (materials.Exists(x => x == oldItem))
                    {
                        int index = materials.IndexOf(oldItem);
                        materials.Insert((index + 1), newItem);
                    }
                }
                else if (action == "Renew")
                {
                    if (materials.Exists(x => x == item))
                    {
                        int index = materials.IndexOf(item);
                        materials.RemoveAt(index);
                        materials.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ",materials));
        }
    }
}
