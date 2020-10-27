using System;
using System.Collections.Generic;
using System.Text;

namespace _13._VehicleCatalogueV2
{
    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsepower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder stringb = new StringBuilder();

            stringb.AppendLine(Type == "car" ? "Type: Car" : "Type: Truck");
            stringb.AppendLine($"Model: {Model}");
            stringb.AppendLine($"Color: {Color}");
            stringb.AppendLine($"Horsepower: {HorsePower}");

            return stringb.ToString().TrimEnd();
        }
    }

}
