using System;
using System.Collections.Generic;
using System.Text;

namespace _03.RaidingHeroes
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
