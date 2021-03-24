using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;

        [SetUp]
        public void Setup()
        {
            make = "Mazda";
            model = "3";
            fuelConsumption = 10;
            fuelCapacity = 100;

            car = new Car(make,model,fuelConsumption,fuelCapacity);
        }

        [Test]
        public void When_CarIsCreated_MakeProperty_ShouldBeSet()
        {
            Assert.AreEqual(car.Make, make);
        }
        [Test]
        public void When_CarIsCreated_ModelProperty_ShouldBeSet()
        {
            Assert.AreEqual(car.Model, model);
        }
        [Test]
        public void When_CarIsCreated_FuelConsumptionProperty_ShouldBeSet()
        {
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
        }
        [Test]
        public void When_CarIsCreated_FuelCapacityProperty_ShouldBeSet()
        {
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
        }

        [Test]
        [TestCase("","3",10,100)]
        [TestCase(null,"3",10,100)]
        [TestCase("Mazda","",10,100)]
        [TestCase("Mazda",null,10,100)]
        [TestCase("Mazda","3",0,100)]
        [TestCase("Mazda","3",-5,100)]
        [TestCase("Mazda","3",10,0)]
        [TestCase("Mazda","3",10,-5)]
        public void When_PropertiesAreInvalid_ShouldThrowArgumentException(string make, string model,double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void When_RefuelMethodIsCalled_FuelAmount_ShouldIncrease()
        {
            double expectedFuelAmount = car.FuelCapacity / 2;

            car.Refuel(expectedFuelAmount);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void When_RefuelMethodIsCalled_WithFuelAmountLargerThanCapacity_AmountShouldBecomeEqualToCapacity()
        {
            double fuelToAdd = car.FuelCapacity * 1.2;

            car.Refuel(fuelToAdd);

            double expectedFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, car.FuelCapacity);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void When_RefuelMethodIsCalled_WithZeroOrNegativeFuel_ShouldThrowException(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        public void When_DriveMethodIsCalled_FuelAmount_ShouldDecreaseWithFuelNeeded()
        {
            car.Refuel(fuelCapacity);

            double distance = 50;

            car.Drive(distance);

            double expectedFuelAmount = 95;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void When_DriveMethodIsCalled_WithCurrentFuelAmount_SmallerThanNeededFuel_ShouldThrowExcepttion()
        {
            double distance = 50;
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
    }
}