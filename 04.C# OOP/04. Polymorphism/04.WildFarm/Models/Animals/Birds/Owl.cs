using _04.WildFarm.Models.Abstract;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double baseWeightModifier = 0.25;

        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };
        public Owl(string name, double weight, double wingSize) : base(name, weight, allowedFoods, baseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
