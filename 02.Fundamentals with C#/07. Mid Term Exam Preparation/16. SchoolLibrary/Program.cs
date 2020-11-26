using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split("&").ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] commandArr = command.Split(" | ");

                string action = commandArr[0];
                string propertyOne = commandArr[1];

                if (action == "Add Book")
                {
                    if (!books.Exists(x => x == propertyOne))
                    {
                        books.Insert(0, propertyOne);
                    }
                }
                else if (action == "Take Book")
                {
                    if (books.Exists(x => x == propertyOne))
                    {
                        books.Remove(propertyOne);
                    }
                }
                else if (action == "Swap Books")
                {
                    string propertyTwo = commandArr[2];
                    if (books.Exists(x => x == propertyOne) && books.Exists(x => x == propertyTwo))
                    {
                        int bookOne = books.IndexOf(propertyOne);
                        int bookTwo = books.IndexOf(propertyTwo);

                        string hold = books[bookTwo];
                        books[bookTwo] = books[bookOne];
                        books[bookOne] = hold;
                    }
                }
                else if (action == "Insert Book")
                {
                    books.Add(propertyOne);
                }
                else if (action == "Check Book")
                {
                    int index = int.Parse(propertyOne);

                    if (index >= 0 && index <= books.Count - 1)
                    {
                        Console.WriteLine(books[index]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
