using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> foodTable = new Dictionary<int, string>()
            {
                {25, "Bread"},
                {50, "Cake"},
                {75, "Pastry"},
                {100, "Fruit Pie"}
            };

            List<int> liquids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> ingredients = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();

            SortedDictionary<string, int> cookedFoods = new SortedDictionary<string, int>() 
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 }
            };

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int sumOfValue = liquids[0] + ingredients[0];

                if (foodTable.ContainsKey(sumOfValue))
                {
                    cookedFoods[foodTable[sumOfValue]]++;
                    liquids.RemoveAt(0);
                    ingredients.RemoveAt(0);
                }
                else
                {
                    liquids.RemoveAt(0);
                    ingredients[0] += 3;
                }
            }

            if (cookedFoods.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var dish in cookedFoods)
            {
                Console.WriteLine($"{dish.Key}: {dish.Value}");
            }
        }
    }
}
