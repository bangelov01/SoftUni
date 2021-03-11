using _04.WildFarm.Models.Abstract;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double baseWeightModifier = 0.40;

        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) : base(name, weight, allowedFoods, baseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
