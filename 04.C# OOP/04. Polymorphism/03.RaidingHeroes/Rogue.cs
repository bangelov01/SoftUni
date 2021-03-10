using System;
using System.Collections.Generic;
using System.Text;

namespace _03.RaidingHeroes
{
    public class Rogue : BaseHero
    {
        private const int power = 80;
        public Rogue(string name)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
