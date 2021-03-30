using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int minHorsepower = 400;
        private const int maxHorsepower = 600;
        private const double cubicCentimeters = 5000;
        private int horsePower;

        public MuscleCar(string model, int horsePower) 
            : base(model,horsePower)
        {
        }

        public override int HorsePower 
        { 
            get => this.horsePower; 
            protected set
            {
                if (value < minHorsepower || value > maxHorsepower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public override double CubicCentimeters => cubicCentimeters;

        public override double CalculateRacePoints(int laps)
        {
            double result = (double)(cubicCentimeters / this.horsePower * laps);

            return result;
        }
    }
}
