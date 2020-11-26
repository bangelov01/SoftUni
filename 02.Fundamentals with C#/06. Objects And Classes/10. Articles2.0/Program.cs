using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articleInput = Console.ReadLine().Split(", ");

                string title = articleInput[0];
                string content = articleInput[1];
                string author = articleInput[2];

                Article article = new Article(title, content, author);
                articles.Add(article);
            }

            string orderBy = Console.ReadLine();

            switch (orderBy)
            {
                case "title":
                    articles = articles.OrderBy(x => x.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(x => x.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(x => x.Author).ToList();
                    break;
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}
