using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, List<Tire> tires)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Engine = engine;
            Tires = tires;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public List<Tire> Tires { get; set; }

        public void Drive()
        {
            FuelQuantity -= 20 * FuelConsumption / 100;
        }

        public override string ToString()
        {
            return $"Make: {Make}\r\nModel: {Model}\r\nYear: {Year}\r\nHorsePowers: {Engine.HorsePowwer}\r\nFuelQuantity: {FuelQuantity}";
        }
    }
}
