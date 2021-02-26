using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultFuelConsumption = 10;
        public SportCar(int horsepower, double fuel) 
            : base(horsepower,fuel)
        {
        }

        public override double FuelConsumption => defaultFuelConsumption;
    }
}
