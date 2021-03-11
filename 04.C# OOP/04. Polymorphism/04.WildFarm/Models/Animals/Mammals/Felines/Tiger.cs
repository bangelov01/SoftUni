using _04.WildFarm.Models.Abstract;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double baseWeightModifier = 1.00;

        private static HashSet<string> allowedFoods = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, allowedFoods, baseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
