using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Abstract
{
    public abstract class Animal
    {
        protected int foodeaten;
        protected Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodeaten;
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }

        private HashSet<string> AllowedFoods { get; set; }
        private double WeightModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        protected int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(food.GetType().Name))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightModifier;
        }
    }
}
