using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._NeedForSpeed
{
    class CarInfo
    {
        public CarInfo(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            Dictionary<string, CarInfo> carsDic = new Dictionary<string, CarInfo>();

            while (numberOfCars > 0)
            {
                string[] cars = Console.ReadLine().Split("|",StringSplitOptions.RemoveEmptyEntries);

                CarInfo addCar = new CarInfo(int.Parse(cars[1]), int.Parse(cars[2]));

                carsDic.Add(cars[0], addCar);

                numberOfCars--;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] commadArr = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string action = commadArr[0];
                string carName = commadArr[1];

                if (action == "Drive")
                {
                    int distance = int.Parse(commadArr[2]);
                    int fuel = int.Parse(commadArr[3]);

                    if (fuel > carsDic[carName].Fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carsDic[carName].Mileage += distance;
                        carsDic[carName].Fuel -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (carsDic[carName].Mileage > 100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        carsDic.Remove(carName);
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(commadArr[2]);
                    int totalFuel = fuel + carsDic[carName].Fuel;
                    if (totalFuel <= 75)
                    {
                        carsDic[carName].Fuel += fuel;
                    }
                    else
                    {
                        fuel = 75 - carsDic[carName].Fuel;
                        carsDic[carName].Fuel += fuel;
                    }

                    Console.WriteLine($"{carName} refueled with {fuel} liters");
                }
                else if (action == "Revert")
                {
                    int kilometers = int.Parse(commadArr[2]);

                    carsDic[carName].Mileage -= kilometers;

                    Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");

                    if (carsDic[carName].Mileage < 10000)
                    {
                        carsDic[carName].Mileage = 10000;
                    }
                }
            }

            foreach (var car in carsDic.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt."
);
            }
        }
    }
}
