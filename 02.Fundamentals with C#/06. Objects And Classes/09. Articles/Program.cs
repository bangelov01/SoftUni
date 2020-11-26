using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string title = input[0];
            string content = input[1];
            string author = input[2];

            int numCommands = int.Parse(Console.ReadLine());

            Article article = new Article(title, content,author);

            for (int i = 0; i < numCommands; i++)
            {
                string[] editInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string change = editInput[1];

                if (editInput[0] == "Edit")
                {
                    EditContent(article, change);
                }
                else if (editInput[0] == "ChangeAuthor")
                {
                    EditAuthor(article, change);
                }
                else
                {
                    EditTitle(article, change);
                }
            }

            Console.WriteLine(article.ToString());
        }

        public static void EditContent(Article article, string change)
        {
            article.Content = change;
        }

        public static void EditAuthor(Article article, string change)
        {
            article.Author = change;
        }
        public static void EditTitle(Article article, string change)
        {
            article.Title = change;
        }
    }
}
