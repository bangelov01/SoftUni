using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior mainWarrior;
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void Setup()
        {
            name = "Stamat";
            damage = 100;
            hp = 1000;
            mainWarrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void When_WarriorIsInitialized_Properties_ShouldBeSetT()
        {
            Assert.AreEqual(name, mainWarrior.Name);
            Assert.AreEqual(damage, mainWarrior.Damage);
            Assert.AreEqual(hp, mainWarrior.HP);
        }

        [Test]
        [TestCase("  ", 10, 100)]
        [TestCase(null, 10, 100)]
        [TestCase("Nikolai", 0, 100)]
        [TestCase("Nikolai", -5, 100)]
        [TestCase("Nikolai", 10, -5)]
        public void When_PropertiesAreInvalid_ShouldThrowArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Boiko", 5, 100)]
        [TestCase("Boiko", 100, 100)]
        public void When_AttackingWarriorHasMoreOrEqualHp_ShouldReduceWith_AttackedWarriorDamage(string name, int damage, int hp)
        {
            Warrior attackedWarrior = new Warrior(name,damage,hp);

            int expectedHp = mainWarrior.HP - damage;

            mainWarrior.Attack(attackedWarrior);

            Assert.AreEqual(expectedHp, mainWarrior.HP);
        }

        [Test]
        public void When_AttackingWarriorHasMoreDamage_ThanAttackedWarriorHp_ShouldBecomeZero()
        {
            string name = "Boiko";
            int damage = 50;
            int hp = 90;
            Warrior attackedWarrior = new Warrior(name, damage, hp);

            mainWarrior.Attack(attackedWarrior);

            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }
        [Test]
        [TestCase("Boiko", 50, 1000)]
        [TestCase("Boiko", 50, 100)]
        public void When_AttackingWarriorHasLessDamage_ThanAttackedWarriorHp_AttackedWarriorHp_ShouldReduce(string name, int damage, int hp)
        {
            Warrior attackedWarrior = new Warrior(name, damage, hp);

            int expectedHp = attackedWarrior.HP - mainWarrior.Damage;

            mainWarrior.Attack(attackedWarrior);

            Assert.AreEqual(expectedHp,attackedWarrior.HP);
        }

        [Test]
        [TestCase("Boiko", 10,20)]
        [TestCase("Boiko", 10,30)]
        public void When_AttackingWarriorHp_IsLessOrEqualToMinimumHp_ShouldThrowWxception(string name, int damage, int hp)
        {
            Warrior attackingWarrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(mainWarrior));
        }
        [Test]
        [TestCase("Boiko", 10, 20)]
        [TestCase("Boiko", 10, 30)]
        public void When_AttackedWarriorHp_IsLessOrEqualToMinimumHp_ShouldThrowWxception(string name, int damage, int hp)
        {
            Warrior attackedWarrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => mainWarrior.Attack(attackedWarrior));
        }

        [Test]
        public void When_AttackingWarriorHp_IsLessThan_AttackedWarriorDamage_ShouldThrowException()
        {
            string name = "Boiko";
            int damage = 1005;
            int hp = 90;
            Warrior attackedWarrior = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() => mainWarrior.Attack(attackedWarrior));
        }
    }
}