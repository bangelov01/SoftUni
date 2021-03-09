using _02.VehiclesExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPolymorphism.Models
{
    public class Truck : Vehicle
    {
        private const double airConditionerModifier = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, airConditionerModifier)
        {
        }

        public override void Refuel(double amount)
        {
            Validator.ThrowIfAmountLessOrEqualToZero(amount, $"Fuel must be a positive number");
            Validator.ThrowIfFuelIsTooMuch(amount, this.TankCapacity);

            double calcLeak = amount * 0.95;

            FuelQuantity += calcLeak;
        }
    }
}
