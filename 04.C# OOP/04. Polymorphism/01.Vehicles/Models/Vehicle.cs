using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPolymorphism.Models
{
    public abstract class Vehicle
    {

        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerModifier)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
        }

        public double FuelQuantity { get;  set; }
        public double FuelConsumption { get;  set; }
        protected double AirConditionerModifier { get;  set; }

        public void Drive(double distance) 
        {
            double consumed = distance * (FuelConsumption + AirConditionerModifier);

            double quantity = FuelQuantity - consumed;

            if (quantity <= 0)
            {
                throw new InvalidOperationException($"{GetType().Name} needs refueling");
            }

            FuelQuantity -= consumed;
        }
        public abstract void Refuel(double amount);
    }
}
