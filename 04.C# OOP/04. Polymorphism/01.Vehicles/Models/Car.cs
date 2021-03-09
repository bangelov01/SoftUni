using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPolymorphism.Models
{
    public class Car : Vehicle
    {
        private const double airConditionerModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption,airConditionerModifier)
        {
        }

        public override void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }
    }
}
