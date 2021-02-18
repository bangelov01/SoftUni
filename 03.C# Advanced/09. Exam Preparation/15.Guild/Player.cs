using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        private string description = "n/a";
        private string rank = "Trial";

        public Player(string name, string clas)
        {
            Name = name;
            Class = clas;
            Rank = rank;
            Description = description;
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Player {Name}: {Class}");
            sb.AppendLine($"Rank: {Rank}");
            sb.AppendLine($"Description: {Description}");

            return sb.ToString().Trim();
        }
    }
}
