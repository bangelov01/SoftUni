using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;

        protected Car(string model, int horsePower)
        {
            Model = model;
            HorsePower = horsePower;
        }

        public string Model 
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public abstract double CalculateRacePoints(int laps);
    }
}
