using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _13._VehicleCatalogueV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Catalogue addVehicle = new Catalogue();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split(" ");

                string type = inputArr[0].ToLower();
                string model = inputArr[1];
                string color = inputArr[2];
                int horsepower = int.Parse(inputArr[3]);

                Vehicle newVehicle = new Vehicle(type, model, color, horsepower);
                addVehicle.Vehicle.Add(newVehicle);
            }

            string carModel = string.Empty;

            while ((carModel = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle printCar = addVehicle.Vehicle.First(x => x.Model == carModel);

                Console.WriteLine(printCar);
            }

            double carHp = addVehicle.Vehicle.Where(x => x.Type == "car").Sum(x => x.HorsePower);
            int carCount = addVehicle.Vehicle.Count(x => x.Type == "car");
            double truckHp = addVehicle.Vehicle.Where(x => x.Type == "truck").Sum(x => x.HorsePower);
            int truckCount = addVehicle.Vehicle.Count(x => x.Type == "truck");

            double avgTruckHp = 0;
            double avgCarHp = 0;

            if (carCount > 0)
            {
                 avgCarHp = (carHp / carCount);
            }
            if (truckCount > 0)
            {
                avgTruckHp = (truckHp / truckCount);
            }

            Console.WriteLine($"Cars have average horsepower of: {avgCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHp:f2}.");
        }
    }
}
