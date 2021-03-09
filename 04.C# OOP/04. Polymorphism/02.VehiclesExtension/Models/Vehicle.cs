using _02.VehiclesExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPolymorphism.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double airConditionerModifier)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            AirConditionerModifier = airConditionerModifier;
        }

        public double FuelQuantity 
        {
            get => this.fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get;  set; }
        public double TankCapacity { get; set; }
        protected double AirConditionerModifier { get;  set; }

        public void Drive(double distance) 
        {
            double consumed = distance * (FuelConsumption + AirConditionerModifier);

            double quantity = FuelQuantity - consumed;

            Validator.ThrowIfAmountLessOrEqualToZero(quantity, $"{GetType().Name} needs refueling");

            FuelQuantity -= consumed;
        }
        public virtual void Refuel(double amount) 
        {
            Validator.ThrowIfAmountLessOrEqualToZero(amount, $"Fuel must be a positive number");
            Validator.ThrowIfFuelIsTooMuch(amount, this.TankCapacity);

            this.FuelQuantity += amount;
        }
    }
}
