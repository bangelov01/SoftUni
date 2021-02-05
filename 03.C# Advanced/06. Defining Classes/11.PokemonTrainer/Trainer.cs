using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private int numberOfBadges = 0;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            Pokemon = new List<Pokemon>();
        }

        public Trainer(string name, int numberOfBadges) : this(name)
        {
            NumberOfBadges = numberOfBadges;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }

    }
}
