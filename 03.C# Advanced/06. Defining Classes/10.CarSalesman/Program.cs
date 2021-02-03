using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            List<Engine> engineList = new List<Engine>();
            List<Car> carList = new List<Car>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine newEngine = new Engine(model,power);

                if (engineInfo.Length - 1 == 2 )
                {

                    string displacementOrEff = engineInfo[2];
                    int result = 0;
                    bool tryToParse = int.TryParse(displacementOrEff, out result);
                    if (tryToParse)
                    {
                        newEngine = new Engine(model, power, displacementOrEff, newEngine.Efficiency);
                    }
                    else
                    {
                        newEngine = new Engine(model, power, newEngine.Displacement, displacementOrEff);
                    }
                    
                }
                else if (engineInfo.Length - 1 == 3)
                {
                    string displacement = engineInfo[2];
                    string efficiency = engineInfo[3];
                    newEngine = new Engine(model, power, displacement, efficiency);
                }

                engineList.Add(newEngine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                Engine currEngine = engineList.FirstOrDefault(e => e.Model == carInfo[1]);

                Car newCar = new Car(model, currEngine);

                if (carInfo.Length - 1 == 2)
                {
                    string weightOrColor = carInfo[2];
                    int result = 0;
                    bool tryToParse = int.TryParse(weightOrColor,out result);
                    if (tryToParse)
                    {

                        newCar = new Car(model, currEngine, weightOrColor, newCar.Color);
                    }
                    else
                    {
                        newCar = new Car(model, currEngine,newCar.Weight,weightOrColor);
                    }
                }
                else if (carInfo.Length - 1 == 3)
                {
                    string weight = carInfo[2];
                    string color = carInfo[3];
                    newCar = new Car(model, currEngine, weight, color);
                }

                carList.Add(newCar);
            }

            foreach (var car in carList)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
