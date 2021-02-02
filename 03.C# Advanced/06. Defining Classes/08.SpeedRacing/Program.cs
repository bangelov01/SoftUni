using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int carsNum = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            while (carsNum > 0)
            {
                string[] carsInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carsInfo[0];
                double fuelAmount = double.Parse(carsInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(carsInfo[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(newCar);

                carsNum--;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commandArr[1];
                double amountOfKm = double.Parse(commandArr[2]);

                Car carToDrive = cars.FirstOrDefault(x => x.Model == model);

                carToDrive.Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }
        }
    }
}
