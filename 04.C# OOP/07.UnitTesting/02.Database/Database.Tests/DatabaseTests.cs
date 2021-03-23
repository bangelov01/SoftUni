using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private int[] nums;
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            nums = new int[5] { 1, 2, 3, 4, 5 };
            database = new Database.Database();
        }

        [Test]
        public void When_IsInitialized_CountShouldBeSet()
        {
            database = new Database.Database(nums);

            Assert.AreEqual(database.Count, nums.Length);
        }

        [Test]
        public void When_Initialized_WithInputAboveThreshold_ShouldThrowException()
        {
            int[] nums = new int[17];

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }

            Assert.Throws<InvalidOperationException>(() => new Database.Database(nums));
        }

        [Test]
        public void When_AddMethodIsUsed_CountShould_Increase()
        {
            int timesAdded = 4;

            for (int i = 0; i < timesAdded; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(timesAdded, database.Count);
            
        }

        [Test]
        public void When_AddMethodIsUsed_WithInputAboveThreshold_ShouldThrowException()
        {
            int inputTimes = 17;

            Assert.Throws<InvalidOperationException>(() => 
            {
                for (int i = 0; i < inputTimes; i++)
                {
                    database.Add(i);
                }
            });
        }

        [Test]
        public void When_FetchMethodIsUsed_ShouldReturnArrayCopy()
        {
            database = new Database.Database(nums);

            int[] firstArray = database.Fetch();

            database.Add(6);

            int[] secondArray = database.Fetch();

            Assert.IsFalse(firstArray == secondArray);
        }

        [Test]
        public void When_AddMethodIsUsed_LastElement_ShouldBeEqualTo_GivenElemnt()
        {
            int elementToAdd = 1;

            database.Add(elementToAdd);

            int[] fetched = database.Fetch();

            Assert.AreEqual(elementToAdd, fetched[0]);
        }

        [Test]
        public void When_RemoveMethodIsUsed_Count_ShouldDecrease()
        {
            database = new Database.Database(nums);

            int expectedCount = nums.Length - 1;

            database.Remove();

            Assert.AreEqual(database.Count, expectedCount);
        }

        [Test]
        public void When_RemoveMethodIsUsed_WithCountEqualToOrLessThanZero_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}