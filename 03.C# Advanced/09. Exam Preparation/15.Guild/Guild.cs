using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> players;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            players = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get{ return players.Count; } }

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var player = players.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                return false;
            }
            players.Remove(player);
            return true;
        }

        public void PromotePlayer(string name)
        {
            var player = players.First(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var player = players.First(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            var toReturn = players.Where(x => x.Class == clas).ToArray();
            players.RemoveAll(x => x.Class == clas);

            return toReturn;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
