using _04.WildFarm.Models.Abstract;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double baseWeightModifier = 0.10;

        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit)
        };
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, allowedFoods, baseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
