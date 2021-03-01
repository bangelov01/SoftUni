using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PizzaCalories
{
    public class Dough
    {
        private string type;
        private string bakingTechnique;
        private double weight;
        private const double white = 1.5;
        private const double wholeGrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;
        private const double caloriesPerGram = 2;

        public Dough(string type, string bakingTechnique, double weight)
        {
            Type = type;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string Type 
        { 
            get => this.type; 
            private set
            {
                string holder = value.ToLower();

                if (holder != "white" && holder != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.type = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                string holder = value.ToLower();

                if (holder != "crispy" && holder != "chewy" && holder != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value <= 0 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double CaloriesPerGram { get => GetTotalCalories(); }

        private double GetTotalCalories()
        {
            double bakingHolder = 0;
            double typeHolder = 0;

            string typeLow = type.ToLower();
            string techniqueLow = bakingTechnique.ToLower();

            switch (typeLow)
            {
                case "white": typeHolder = white; break;
                case "wholegrain": typeHolder = wholeGrain; break;
            }

            switch (techniqueLow)
            {
                case "crispy": bakingHolder = crispy; break;
                case "chewy": bakingHolder = chewy; break;
                case "homemade": bakingHolder = homemade; break;
            }

            return (caloriesPerGram * weight) * typeHolder * bakingHolder;
        }
    }
}
