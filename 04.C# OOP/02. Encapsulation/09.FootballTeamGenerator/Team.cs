using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private HashSet<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new HashSet<Player>();
        }
        public string Name 
        {
            get => this.name;
            private set
            {
                Validator.IfIsNullEmptyOrWhiteSpace(value, "A name should not be empty.");

                this.name = value;
            } 
        }
        public decimal GetRating()
        {
            decimal average = 0;

            foreach (var player in players)
            {
                average += player.GetSkillLevel();
            }

            if (players.Count > 0)
            {
                return Math.Round(average /= players.Count);
            }

            return 0;
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(x => x.Name == playerName);

            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }

            players.Remove(player);
        }
    }
}
