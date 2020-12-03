using System;
using System.Collections.Generic;
using System.Text;

namespace _06._HeroesOfCodeAndLogic
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
}
