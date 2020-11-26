using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commandArr = command.Split(" ");

                string toDo = commandArr[0];
                string item = commandArr[1];

                switch (toDo)
                {
                    case "Urgent":
                        if (!groceries.Exists(x => x == item))
                        {
                            groceries.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":
                        if (groceries.Exists(x => x == item))
                        {
                            groceries.Remove(item);
                        }
                        break;
                    case "Correct":

                        string oldItem = item;
                        string newItem = commandArr[2];

                        if (groceries.Exists(x => x == oldItem))
                        {
                            int index = groceries.IndexOf(oldItem);
                            groceries.RemoveAt(index);
                            groceries.Insert(index, newItem);
                        }
                        break;
                    case "Rearrange":
                        if (groceries.Exists(x => x == item))
                        {
                            groceries.Remove(item);
                            groceries.Add(item);
                        }
                        break;
                }                
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
