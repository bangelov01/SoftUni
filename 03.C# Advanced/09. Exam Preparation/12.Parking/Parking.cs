using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
   public class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            cars = new List<Car>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public int Count { get { return cars.Count; } }

        public void Add(Car car)
        {
            if (cars.Count < Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var neededCar = cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (neededCar == null)
            {
                return false;
            }

            cars.Remove(neededCar);
            return true;
        }

        public Car GetLatestCar()
        {
            var ordered = cars.OrderByDescending(x => x.Year);

            return ordered.FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
