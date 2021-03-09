using CSharpPolymorphism.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double airConditionerModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity, airConditionerModifier)
        {
        }

        public void DriveEmpty(double distance)
        {
            base.AirConditionerModifier = 0;
            base.Drive(distance);
        }
    }
}
