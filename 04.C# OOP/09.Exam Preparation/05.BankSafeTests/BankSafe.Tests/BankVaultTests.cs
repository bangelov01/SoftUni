using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankVault;
        private readonly string[] cells = { "A1", "A2", "A3", "A4", "B1", "B2", "B3", "B4", "C1", "C2", "C3", "C4", "D1" };

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void When_BankVaultIsInitiated_DictionaryCount_ShouldBeTwelve()
        {
            int expectedCount = 12;

            Assert.AreEqual(expectedCount, bankVault.VaultCells.Count);
        }

        [Test]
        public void When_BankVaultIsInitiated_Dictionary_ShouldBeCreated()
        {
            var expected = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEquivalent(expected, bankVault.VaultCells);
        }

        [Test]
        public void When_AddItemIsCalld_ShouldAddItem()
        {
            var item = CreateItem();

            string expected = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(expected, bankVault.AddItem(cells[0], item));
        }

        [Test]
        public void When_AddItemIsCalld_WithInvalidCell_ShouldThrowException()
        {
            var item = CreateItem();

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cells[cells.Length - 1], item));
        }

        [Test]
        public void When_AddItemIsCalld_WithAlreadyTakenCell_ShouldThrowException()
        {
            var firstItem = CreateItem();

            bankVault.AddItem(cells[0],firstItem);

            var secondItem = new Item("Owner2", "2");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cells[0],secondItem));

        }

        [Test]
        public void When_AddItemIsCalld_WithItemAlreadyInCell_ShouldThrowException()
        {
            var item = CreateItem();

            bankVault.AddItem(cells[5], item);

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem(cells[0], item));

        }

        [Test]
        public void When_RemoveItemIsCalled_ItemShouldBeRemoved()
        {
            var item = CreateItem();

            bankVault.AddItem(cells[5], item);

            var expected = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expected, bankVault.RemoveItem(cells[5], item));
        }

        [Test]
        public void When_RemoveItemIsCalled_WithNonExistantCell_ShouldThrowException()
        {
            var item = CreateItem();

            bankVault.AddItem(cells[5], item);

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cells[cells.Length - 1], item));
        }

        [Test]
        public void When_RemoveItemIsCalled_WithInvalidItem_ShouldThrowException()
        {
            var item = CreateItem();

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cells[0], item), "Item in that cell doesn't exists!");
        }

        private Item CreateItem()
        {
            return new Item("Owner","1");
        }
    }
}