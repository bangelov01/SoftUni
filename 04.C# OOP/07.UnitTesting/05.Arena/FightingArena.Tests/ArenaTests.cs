using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void When_ArenaIsInitialized_CollectionShouldBeCreated()
        {
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void When_ArenaIsInitialized_CollectionCountShouldBeSet()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_EnrollMethodIsCalled_Warrior_ShouldBeAdded()
        {
            Warrior warrior = new Warrior("Boiko", 5, 10);
            arena.Enroll(warrior);

            CollectionAssert.Contains(arena.Warriors, warrior);
        }
        [Test]
        public void When_EnrollMethodIsCalled_WithValidInput_CountShouldIncrease()
        {
            Warrior warrior = new Warrior("Boiko", 5, 10);
            Warrior warriorTwo = new Warrior("Nikolai", 5, 10);
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, arena.Count);
        }
        [Test]
        public void When_EnrollMethodIsCalled_WithExistingWarrior_ShouldThrowException()
        {
            Warrior warrior = new Warrior("Boiko", 5, 10);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        [TestCase("Pesho", "Bobi")]
        [TestCase("Pesho", "Boiko")]
        [TestCase("Boiko", "Pesho")]
        public void When_FightMethodIsCalled_WithInvalidAttackerOrDefender_ShouldThrowException(string attacker, string defender)
        {
            Warrior warrior = new Warrior("Boiko", 5, 10);
            Warrior warriorTwo = new Warrior("Nikolai", 5, 10);
            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
        }
        [Test]
        public void When_FightMethodIsCalled_WithValidWarriors_WarriorsShouldAttack()
        {
            int initialHp = 100;

            Warrior attacker = new Warrior("Pesho", 50, initialHp);
            Warrior defender = new Warrior("Gosho", 50, initialHp);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(attacker.HP, (initialHp - defender.Damage));
            Assert.AreEqual(defender.HP, (initialHp - attacker.Damage));
        }
    }
}
