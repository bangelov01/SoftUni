using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;
        private double caloriesPerGram = 2;
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type 
        {
            get => type;
            private set
            {
                string holder = value.ToLower();

                if (holder != "meat" && holder != "veggies" && holder != "cheese" && holder != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            } 
        }
        public double Weight 
        {
            get => weight;
            private 
                set
            {
                if (value <= 0 || value > 50)
                {
                    throw new Exception($"{type} weight should be in the range [1..50].");
                }

                weight = value;
            } 
        }

        public double CaloriesPerGram { get => GetTotalCalories(); }

        private double GetTotalCalories()
        {
            double typeHolder = 0;
            string holder = type.ToLower();

            switch (holder)
            {
                case "meat": typeHolder = meat; break;
                case "veggies": typeHolder = veggies; break;
                case "cheese": typeHolder = cheese; break;
                case "sauce": typeHolder = sauce; break;
            }
            return (caloriesPerGram * weight) * typeHolder;
        }
    }
}
