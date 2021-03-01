using System;
using System.Collections.Generic;
using System.Text;

namespace _02.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name 
        {
            get => name;
            private set
            {
                string holder = value.ToLower();

                if (holder.Length > 15 || holder.Length <= 0 || string.IsNullOrEmpty(holder) || string.IsNullOrWhiteSpace(holder))
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough { get; set; }

        public int NumberOfToppings { get => toppings.Count; }

        public double GetTotalCalories { get => GetCalories(); }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
        private double GetCalories()
        {
            double calories = 0;

            foreach (var item in toppings)
            {
                calories += item.CaloriesPerGram;
            }

            calories += Dough.CaloriesPerGram;

            return calories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetTotalCalories:f2} Calories.";
        }
    }
}
