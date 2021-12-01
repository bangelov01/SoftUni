namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var desGames = JsonConvert.DeserializeObject<IEnumerable<ImportGameDTO>>(jsonString);

			var sb = new StringBuilder();

			var games = new HashSet<Game>();

			var existingDevelopers = new HashSet<Developer>();
			var existingTags = new HashSet<Tag>();
			var existingGenres = new HashSet<Genre>();

			foreach (var game in desGames)
            {
                if (!IsValid(game))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

                if (!DateTime.TryParse(game.ReleaseDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue ))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var newGame = new Game
				{
					Name = game.Name,
					ReleaseDate = dateValue,
					Price = game.Price
				};

                if (!existingDevelopers.Any(x => x.Name == game.Developer))
                {
					existingDevelopers.Add(new Developer { Name = game.Developer });
                }

				newGame.Developer = existingDevelopers.First(x => x.Name == game.Developer);

                if (!existingGenres.Any(x => x.Name == game.Genre))
                {
					existingGenres.Add(new Genre { Name = game.Genre });
                }

				newGame.Genre = existingGenres.First(x => x.Name == game.Genre);

				//var gameTags = new HashSet<GameTag>();

                foreach (var tag in game.Tags)
                {
					if (!existingTags.Any(x => x.Name == tag))
					{
						existingTags.Add(new Tag { Name = tag });
					}

					//gameTags.Add(new GameTag
					//{
					//	Game = newGame,
					//	Tag = existingTags.First(x => x.Name == tag)
					//});
				}

				//newGame.GameTags = gameTags;

				games.Add(newGame);
				sb.AppendLine($"Added {newGame.Name} ({newGame.Genre.Name}) with {game.Tags.Length} tags");
			}

			context.Games.AddRange(games);
			context.Tags.AddRange(existingTags);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var desUsers = JsonConvert.DeserializeObject<IEnumerable<ImportUserDTO>>(jsonString);

			var sb = new StringBuilder();

			var filteredUsers = new HashSet<User>();

            foreach (var user in desUsers)
            {
				bool isCardInvalid = false;
				var filteredCards = new HashSet<Card>();

				foreach (var card in user.Cards)
				{
					if (!IsValid(card) || !Enum.TryParse(card.Type, out CardType cType))
					{
						isCardInvalid = true;
						break;
					}

					filteredCards.Add(new Card
					{
						Number = card.Number,
						Cvc = card.CVC,
						Type = cType
					});
				}

				if (!IsValid(user) || !user.Cards.Any() || isCardInvalid)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var newUser = new User
				{
					FullName = user.FullName,
					Username = user.Username,
					Email = user.Email,
					Age = user.Age,
					Cards = filteredCards
				};

				filteredUsers.Add(newUser);

				sb.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count} cards");
            }

			context.Users.AddRange(filteredUsers);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var serializer = GetSerializer("Purchases", typeof(ImportPurchasesDTO[]));

			var deserializedPurchases = (ImportPurchasesDTO[])serializer.Deserialize(new StringReader(xmlString));

			var sb = new StringBuilder();

			var filteredPurchases = new HashSet<Purchase>();

            foreach (var p in deserializedPurchases)
            {
                if (!IsValid(p) || !Enum.TryParse(p.Type, out PurchaseType pType))
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				if (!DateTime.TryParseExact(p.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				var getCard = context.Cards.First(c => c.Number == p.CardNumber);

				var getGame = context.Games.First(g => g.Name == p.GameTitle);

				var newPurchase = new Purchase
				{
					Type = pType,
					Date = dateValue,
					ProductKey = p.ProductKey,
					Game = getGame,
					Card = getCard
				};

				filteredPurchases.Add(newPurchase);

				sb.AppendLine($"Imported {getGame.Name} for {getCard.User.Username}");
			}

			context.Purchases.AddRange(filteredPurchases);
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