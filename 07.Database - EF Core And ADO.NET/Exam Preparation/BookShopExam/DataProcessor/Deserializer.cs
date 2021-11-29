namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var serializer = GetSerializer("Books", typeof(ImportBooksDTO[]));

            var deserializedBooks = (ImportBooksDTO[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var filteredBooks = new HashSet<Book>();

            foreach (var book in deserializedBooks)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                filteredBooks.Add(new Book
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = DateTime.ParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                });

                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(filteredBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var desAuthors = JsonConvert.DeserializeObject<IEnumerable<ImportAuthorsDTO>>(jsonString);

            var sb = new StringBuilder();

            var filteredAuthors = new HashSet<Author>();

            foreach (var a in desAuthors)
            {
                if (!IsValid(a) || filteredAuthors.Any(e => e.Email == a.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var newAuthor = new Author
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Email = a.Email,
                    Phone = a.Phone
                };

                var filteredBooks = new HashSet<AuthorBook>();

                foreach (var b in a.Books)
                {
                    if (!context.Books.Any(x => x.Id == b.Id) || b.Id == null)
                    {
                        continue;
                    }

                    filteredBooks.Add(new AuthorBook
                    {
                        Author = newAuthor,
                        BookId = (int)b.Id
                    });
                }

                if (!filteredBooks.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                newAuthor.AuthorsBooks = filteredBooks;

                filteredAuthors.Add(newAuthor);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{newAuthor.FirstName} {newAuthor.LastName}", newAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(filteredAuthors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}