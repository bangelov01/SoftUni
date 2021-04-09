using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> itemPool;
		public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

            if (characterType != nameof(Priest) && characterType != nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			Character character = null;

            if (characterType == nameof(Priest))
            {
				character = new Priest(name);
            }
            else if (characterType == nameof(Warrior))
            {
				character = new Warrior(name);
			}

			this.party.Add(character);

			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			if (itemName != nameof(FirePotion) && itemName != nameof(HealthPotion))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			Item item = null;

			if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();
			}
			else if (itemName == nameof(HealthPotion))
			{
				item = new HealthPotion();
			}

			this.itemPool.Add(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

            if (!this.party.Any(c => c.Name == characterName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
            if (!this.itemPool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			var character = this.party.FirstOrDefault(c => c.Name == characterName);

			var lastItem = this.itemPool[itemPool.Count - 1]; // test with last
			character.Bag.AddItem(lastItem);

			this.itemPool.RemoveAt(this.itemPool.Count - 1); // remove after full points to test;

			return string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name); // possible error with nameof
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			if (!this.party.Any(c => c.Name == characterName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			var character = this.party.FirstOrDefault(c => c.Name == characterName);

			var neededItem = character.Bag.GetItem(itemName);

			character.UseItem(neededItem);

			return string.Format(SuccessMessages.UsedItem, characterName, neededItem.GetType().Name); // possible error with nameof
		}

		public string GetStats()
		{
			var sorted = this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);

			StringBuilder sb = new StringBuilder();

            foreach (var character in sorted)
            {
				string status = "Alive";

                if (!character.IsAlive)
                {
					status = "Dead";
                }

				sb.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, status));
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

            if (!this.party.Any(c => c.Name == attackerName))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (!this.party.Any(c => c.Name == receiverName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

			var attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
			var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (attacker is Priest)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
			}

            var castToAttacker = (Warrior)attacker; // try with IAttacker

            castToAttacker.Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			if (!this.party.Any(c => c.Name == healerName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (!this.party.Any(c => c.Name == healingReceiverName))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
			}

			var healer = this.party.FirstOrDefault(c => c.Name == healerName);
			var receiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);

			if (healer is Warrior)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
			}

			var castToHealer = (Priest)healer;

			castToHealer.Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
		}
	}
}
