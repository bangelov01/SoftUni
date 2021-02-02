using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance) : this(model, fuelAmount, fuelConsumptionPerKilometer)
        {
            TraveledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }


        public void Drive(double kmAmount)
        {
            double fuelNeeded = (kmAmount * FuelConsumptionPerKilometer);

            if (fuelNeeded <= FuelAmount )
            {
                FuelAmount -= fuelNeeded;
                TraveledDistance += kmAmount;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
