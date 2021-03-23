using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private Person[] peopleAboveThreshold;
        private ExtendedDatabase.ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
            peopleAboveThreshold = new Person[17];
            for (int i = 0; i < peopleAboveThreshold.Length; i++)
            {
                peopleAboveThreshold[i] = new Person(i, $"Username{i}");
            }

            people = new Person[5];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username{i}");
            }

            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void When_Initiated_Count_ShouldBeSet()
        {
            database = new ExtendedDatabase.ExtendedDatabase(people);

            int expectedCount = 5;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void When_Initiated_WithCapacityAboveThreshold_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(peopleAboveThreshold));
        }

        [Test]
        public void When_AddMethodIsUsed_Count_ShouldIncrease()
        {
            database.Add(new Person(1, "Nasko"));

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void When_AddMethodIsUsed_With_LargerThreshold_ShouldThrowException()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < peopleAboveThreshold.Length; i++)
                {
                    database.Add(peopleAboveThreshold[i]);
                }
            });
        }

        [Test]
        public void When_AddMethodIsUsed_And_PersonIdAlreadyExists_ShouldThrowException()
        {
            database.Add(new Person(1, "Nasko"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "Pesho")));
        }

        [Test]
        public void When_AddMethodIsUsed_And_PersonNameAlreadyExists_ShouldThrowException()
        {
            database.Add(new Person(1, "Nasko"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(2, "Nasko")));
        }

        [Test]
        public void When_RemoveMethodIsUsed_Count_ShouldDecrease()
        {
            database = new ExtendedDatabase.ExtendedDatabase(people);

            database.Remove();

            int expectedCount = 4;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void When_RemoveMethodIsUsed_WithNoMoreElements_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void When_FindByUsernameMethodIsUsed_ShouldReturnPerson_WithGivenUsername()
        {
            var expectedPerson = new Person(1, "Pesho");

            database.Add(expectedPerson);

            var resultPerson = database.FindByUsername(expectedPerson.UserName);

            Assert.AreEqual(expectedPerson, resultPerson);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]

        public void When_FindByUsernameMethodIsUsed_WithNullOrEmptyName_ShouldThrowException(string parameter)
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(parameter));
        }

        [Test]
        public void When_FindByUsernameMethodIsUsed_WithInvalidUsername_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Pesheca"));
        }
        [Test]
        public void When_FindByIdIsUsed_ShouldReturnPerson_WithGivenId()
        {
            var expectedPerson = new Person(1, "Pesho");

            database.Add(expectedPerson);

            var resultPerson = database.FindById(expectedPerson.Id);

            Assert.AreEqual(expectedPerson, resultPerson);
        }

        [Test]
        public void When_FindByIdIsUsed_WithNegativeId_ShouldThrowException()
        {
            Person person = new Person(-1, "Gosho");
            database.Add(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(person.Id));
        }

        [Test]
        public void When_FindByIdIsUsed_WithInvalidId_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(1));
        }
    }
}