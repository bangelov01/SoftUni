using _04.WildFarm.Models.Abstract;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double baseWeightModifier = 0.35;

        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Meat),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize) : base(name, weight, allowedFoods, baseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
