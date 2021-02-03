using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string carInfo = Console.ReadLine();
                int spaceCount = 0;
                string tireInfo = string.Empty;
                for (int j = 0; j < carInfo.Length; j++)
                {
                    if (char.IsWhiteSpace(carInfo[j]))
                    {
                        spaceCount++;
                        if (spaceCount == 5)
                        {
                            tireInfo = carInfo.Substring(j + 1);
                            carInfo = carInfo.Remove(j, carInfo.Length - j);
                        }
                    }
                }

                string[] carInfoArr = carInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfoArr[0];
                int engineSpeed = int.Parse(carInfoArr[1]);
                int enginePower = int.Parse(carInfoArr[2]);
                Engine engine = new Engine(engineSpeed,enginePower);

                int cargoWeight = int.Parse(carInfoArr[3]);
                string cargoType = carInfoArr[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                string[] tireInfoArr = tireInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                List<Tire> newTire = new List<Tire>();

                for (int k = 1; k <= tireInfoArr.Length; k++)
                {
                    if (k % 2 != 0)
                    {
                        Tire tireToAdd = new Tire(double.Parse(tireInfoArr[k - 1]), int.Parse(tireInfoArr[k]));
                        newTire.Add(tireToAdd);
                    }
                }

                Car newCar = new Car(model, engine, cargo, newTire);
                cars.Add(newCar);
            }

            string command = Console.ReadLine();

            Predicate<Tire> isPressureLow = p => p.Pressure < 1;

            if (command == "fragile")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "fragile").Where(x => x.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
