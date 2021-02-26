using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;
        public Car(int horsepower, double fuel) 
            : base(horsepower, fuel)
        {
        }

        public override double FuelConsumption => defaultFuelConsumption;
    }
}
