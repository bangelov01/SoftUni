using System;
using System.Collections.Generic;
using System.Text;

namespace _09._NetherRealms
{
    class Demon
    {
        public Demon(string name, double health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public string Name { get; set; }
        public double Health { get; set; }
        public double Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }
}
