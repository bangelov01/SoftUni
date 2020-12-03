using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._HeroesOfCodeAndLogic
{
    class Program
    {
        class HeroInfo
        {
            public HeroInfo(int health, int mana)
            {
                Health = health;
                Mana = mana;
            }
            public int Health { get; set; }
            public int Mana { get; set; }
        }
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            Dictionary<string, HeroInfo> heroesDic = new Dictionary<string, HeroInfo>();

            while (numberOfHeroes > 0)
            {
                string[] heroInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroInfo[0];
                int heroHp = int.Parse(heroInfo[1]);
                int heroMp = int.Parse(heroInfo[2]);
                if (heroHp > 100)
                {
                    heroHp = 100;
                }
                if (heroMp > 200)
                {
                    heroMp = 200;
                }
                heroesDic.Add(heroName, new HeroInfo(heroHp, heroMp));

                numberOfHeroes--;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string action = commandArr[0];
                string heroName = commandArr[1];

                if (action == "CastSpell")
                {
                    int manaNeeded = int.Parse(commandArr[2]);
                    string spellName = commandArr[3];

                    if (heroesDic[heroName].Mana >= manaNeeded)
                    {
                        heroesDic[heroName].Mana -= manaNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroesDic[heroName].Mana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }

                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(commandArr[2]);
                    string attacker = commandArr[3];

                    if (heroesDic[heroName].Health > damage)
                    {
                        heroesDic[heroName].Health -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesDic[heroName].Health} HP left!");
                    }
                    else
                    {
                        heroesDic.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (action == "Recharge")
                {
                    int amount = int.Parse(commandArr[2]);
                    int totalHealMana = amount + heroesDic[heroName].Mana;
                    if (totalHealMana <= 200)
                    {
                        heroesDic[heroName].Mana += amount;
                    }
                    else
                    {
                        amount = 200 - heroesDic[heroName].Mana;
                        heroesDic[heroName].Mana += amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {amount} MP!");

                }
                else if (action == "Heal")
                {
                    int amount = int.Parse(commandArr[2]);
                    int totalHealMana = amount + heroesDic[heroName].Health;
                    if (totalHealMana <= 100)
                    {
                        heroesDic[heroName].Health += amount;
                    }
                    else
                    {
                        amount = 100 - heroesDic[heroName].Health;
                        heroesDic[heroName].Health += amount;
                    }

                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }
            }

            foreach (var hero in heroesDic.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key}\r\n" +
                    $"  HP: {hero.Value.Health}\r\n" +
                    $"  MP: {hero.Value.Mana}");
            }
        }
    }
}
