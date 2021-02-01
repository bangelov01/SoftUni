using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<List<Tire>> tireList = new List<List<Tire>>();
            List<Engine> engineList = new List<Engine>();
            List<Car> carsList = new List<Car>();

            string Info = string.Empty;

            while ((Info = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfoArr = Info.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<Tire> newTire = new List<Tire>();

                for (int i = 1; i <= tireInfoArr.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        Tire tireToAdd = new Tire(int.Parse(tireInfoArr[i - 1]), double.Parse(tireInfoArr[i]));
                        newTire.Add(tireToAdd);
                    }
                }

                tireList.Add(newTire);
            }

            Info = string.Empty;

            while ((Info = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfoArr = Info.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineInfoArr[0]);
                double cubicCapacity = double.Parse(engineInfoArr[1]);

                Engine newEngine = new Engine(horsePower, cubicCapacity);
                engineList.Add(newEngine);
            }

            Info = string.Empty;

            while ((Info = Console.ReadLine()) != "Show special")
            {
                string[] carInfoArr = Info.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = carInfoArr[0];
                string model = carInfoArr[1];
                int year = int.Parse(carInfoArr[2]);
                double fuelQuantity = double.Parse(carInfoArr[3]);
                double fuelCapacity = double.Parse(carInfoArr[4]);
                int engineIndex = int.Parse(carInfoArr[5]);
                int tireIndex = int.Parse(carInfoArr[6]);
                Engine engine = engineList[engineIndex];
                List<Tire> tires = tireList[tireIndex];

                Car newCar = new Car(make, model, year, fuelQuantity, fuelCapacity, engine, tires);
                carsList.Add(newCar);
            }

            foreach (var car in carsList.Where(x => x.Year >= 2017 && x.Engine.HorsePowwer > 330 && x.Tires.Sum(x => x.Pressure) >= 9 && x.Tires.Sum(x => x.Pressure) <= 10))
            {
                car.Drive();
                Console.WriteLine(car.ToString());
            }
        }
    }
}
