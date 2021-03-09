using CSharpPolymorphism.Models;
using System;

namespace CSharpPolymorphism
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(info[1]), double.Parse(info[2]));

            info = Console.ReadLine().Split();

            Vehicle truck = new Truck(double.Parse(info[1]), double.Parse(info[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] actions = Console.ReadLine().Split();

                try
                {
                    if (actions[1] == nameof(Car))
                    {
                        DoAction(car, actions[0], double.Parse(actions[2]));
                    }
                    else if (actions[1] == nameof(Truck))
                    {
                        DoAction(truck, actions[0], double.Parse(actions[2]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        public static void DoAction(Vehicle vehicle, string action,double value)
        {

            if (action == "Drive")
            {
                vehicle.Drive(value);
                Console.WriteLine($"{vehicle.GetType().Name} travelled {value} km");
            }
            else if (action == "Refuel")
            {
                vehicle.Refuel(value);
            }
        }
    }
}
