using System;
using System.Collections.Generic;

namespace _03.RaidingHeroes
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();

            int numberOfHeroes = int.Parse(Console.ReadLine());

            while (raidGroup.Count < numberOfHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = CreateHero(name, type);

                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var member in raidGroup)
            {
                Console.WriteLine(member.CastAbility());
                bossPower -= member.Power;
            }

            if (bossPower <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        public static BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;

            switch (type)
            {
                case "Druid": hero = new Druid(name); break;
                case "Paladin": hero = new Paladin(name); break;
                case "Rogue": hero = new Rogue(name); break;
                case "Warrior": hero = new Warrior(name); break;
            }

            return hero;
        }
    }
}
