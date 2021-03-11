using _04.WildFarm.Models.Abstract;
using _04.WildFarm.Models.Animals.Birds;
using _04.WildFarm.Models.Animals.Mammals;
using _04.WildFarm.Models.Animals.Mammals.Felines;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                input = Console.ReadLine();
                string[] foodInfo = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);

                Animal animal = CreateAnimal(animalInfo);
                Food food = CreateFood(foodInfo);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString()); 
            }
        }

        public static Animal CreateAnimal(string[] animalInfo)
        {
            Animal animal = null;
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalInfo[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalInfo[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalInfo[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Cat(name, weight, livingRegion,breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }

        public static Food CreateFood(string[] foodInfo)
        {
            Food food = null;

            string foodName = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (foodName == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (foodName == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (foodName == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (foodName == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
