namespace BookShop.DataProcessor
{
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var neededAuthors = context.Authors
                .Include(x => x.AuthorsBooks)
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .Select(ab => ab.Book)
                    .OrderByDescending(b => b.Price)
                    .Select(x => new
                    {
                        BookName = x.Name,
                        BookPrice = x.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(neededAuthors, jsonSettings);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var oldestBooks = context.Books
                .ToArray()
                .Where(b => b.PublishedOn < date && b.Genre == Data.Models.Enums.Genre.Science)
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Take(10)
                .Select(x => new ExportOldestBooksDTO
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    PublishedOn = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("Books", typeof(ExportOldestBooksDTO[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, oldestBooks, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }
    }
}