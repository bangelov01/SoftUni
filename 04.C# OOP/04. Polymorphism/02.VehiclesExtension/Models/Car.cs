using _02.VehiclesExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPolymorphism.Models
{
    public class Car : Vehicle
    {
        private const double airConditionerModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, airConditionerModifier)
        {
        }

    }
}
