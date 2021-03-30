using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void When_RaceEntryIsInitialized_CountShouldBeZero()
        {
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, raceEntry.Counter);
        }

        [Test]
        public void When_AddDriverIsCalled_ShouldAddDriver()
        {
            var driver = CreateSingleDriver();

            var result = raceEntry.AddDriver(driver);

            var expected = $"Driver {driver.Name} added in race.";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void When_AddDriverIsCalled_ShouldIncreaseCounter()
        {
            var driver = CreateSingleDriver();

            var result = raceEntry.AddDriver(driver);

            var expected = 1;

            Assert.AreEqual(expected, raceEntry.Counter);
        }

        [Test]

        public void When_AddDriverIsCalled_WithNullDriver_ShouldThrowException()
        {
            UnitDriver driver = null;

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver), "Driver cannot be null.");
        }

        [Test]
        public void When_AddDriverIsCalled_WithAlreadyContainedDriver_ShouldThrowException()
        {
            var driver = CreateSingleDriver();

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver), $"Driver {driver.Name} is already added.");
        }

        [Test]
        public void When_CalcAvgHorsepowerIsCalled_ShouldReturnAvgHorsepower()
        {
            var drivers = CreateMultipleDrivers();

            AddToRaceEntry(drivers);

            var expected = drivers.Select(x => x.Car.HorsePower).Average();

            Assert.AreEqual(expected, raceEntry.CalculateAverageHorsePower());

        }

        [Test]
        public void When_CalcAvgHorsepowerIsCalled_WithBelowMinParticipants_ShouldThrowException()
        {
            var driver = CreateSingleDriver();

            int minimumParticipants = 2;

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), $"The race cannot start with less than {minimumParticipants} participants.");

        }

        private UnitDriver CreateSingleDriver()
        {
            return new UnitDriver("Pesho", new UnitCar("Mazda", 150, 2000));
        }

        private List<UnitDriver> CreateMultipleDrivers()
        {
            int max = 10;

            var result = new List<UnitDriver>();

            UnitDriver unitDriver = null;

            for (int i = 1; i <= max; i++)
            {
                unitDriver = new UnitDriver($"Name{i}", new UnitCar($"Model{i}", 100 + i, 1000 + i));

                result.Add(unitDriver);
            }

            return result;
        }

        private void AddToRaceEntry(List<UnitDriver> driversToAdd)
        {
            foreach (var driver in driversToAdd)
            {
                raceEntry.AddDriver(driver);
            }
        }
    }
}