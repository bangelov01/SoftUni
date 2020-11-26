using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input= string.Empty;

            Catalogue addVehicle = new Catalogue();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArr = input.Split("/");

                string type = inputArr[0];
                string brand = inputArr[1];
                string model = inputArr[2];
                int hpOrWeight = int.Parse(inputArr[3]);

                if (type == "Car")
                {
                    Cars newCar = new Cars(brand, model, hpOrWeight);
                    addVehicle.Cars.Add(newCar);
                }
                else
                {
                    Trucks newTruck = new Trucks(brand, model, hpOrWeight);
                    addVehicle.Trucks.Add(newTruck);
                }
            }

            var orderCars = addVehicle.Cars.OrderBy(x => x.Brand).ToList();
            var orderTrucks = addVehicle.Trucks.OrderBy(y => y.Brand).ToList();

            if (orderCars.Count == 0)
            {
                PrintTrucks(orderTrucks);
            }
            else if (orderTrucks.Count == 0)
            {
                PrintCars(orderCars);
            }
            else
            {
                PrintCars(orderCars);
                PrintTrucks(orderTrucks);
            }
        }

        public static void PrintCars(List<Cars> orderedCars)
        {
            Console.WriteLine("Cars:");

            foreach (Cars car in orderedCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }
        }

        public static void PrintTrucks(List<Trucks> orderedTrucks)
        {
            Console.WriteLine("Trucks:");

            foreach (Trucks truck in orderedTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
