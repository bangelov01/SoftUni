using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPolymorphism.Models
{
    public class Truck : Vehicle
    {
        private const double airConditionerModifier = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, airConditionerModifier)
        {
        }

        public override void Refuel(double amount)
        {
            double calcLeak = amount * 0.95;

            FuelQuantity += calcLeak;
        }
    }
}
