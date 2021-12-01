namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var neededGames = context.Genres
                .Include(x => x.Games)
                .ThenInclude(x => x.GameTags)
                .ToArray()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(x => x.Purchases.Count > 0)
                    .Select(y => new
                    {
                        Id = y.Id,
                        Title = y.Name,
                        Developer = y.Developer.Name,
                        Tags = string.Join(", ", y.GameTags.Select(gt => gt.Tag.Name)),
                        Players = y.Purchases.Count
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToArray(),
					TotalPlayers = g.Games.Sum(ga => ga.Purchases.Count)
				})
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(neededGames, jsonSettings);

		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			Enum.TryParse(storeType, out PurchaseType pValue);

			var neededUsers = context.Users
				.ToArray()
				.Where(u => u.Cards.Any(c => c.Purchases.Count > 0))
				.Select(u => new ExportPurchasesDTO
				{
					Username = u.Username,
					Purchases = context
					.Purchases
					.ToArray()
					.Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(storeType))
					.OrderBy(p => p.Date)
					.Select(p => new PurchaseDTO
					{
						CardNumber = p.Card.Number,
						CVC = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameDTO
						{
							Name = p.Game.Name,
							Genre = p.Game.Genre.Name,
							Price = p.Game.Price
						}
					})
					.ToArray(),
					TotalSpent = context.Purchases
					.ToArray()
					.Where(p => p.Card.User.Username == u.Username && p.Type == Enum.Parse<PurchaseType>(storeType))
					.Sum(p => p.Game.Price)
				})
				.Where(u => u.Purchases.Length > 0)
				.OrderByDescending(u => u.TotalSpent)
				.ThenBy(u => u.Username)
				.ToArray();

			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(String.Empty, String.Empty);

			var serializer = GetSerializer("Users", typeof(ExportPurchasesDTO[]));

			var sb = new StringBuilder();

			using (var writer = new StringWriter(sb))
			{
				serializer.Serialize(writer, neededUsers, namespaces);
			}

			return sb.ToString().TrimEnd();
		}
		public static XmlSerializer GetSerializer(string root, Type dtoType)
		{
			return new XmlSerializer(dtoType, new XmlRootAttribute(root));
		}
	}
}