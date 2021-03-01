using System;
using System.Collections.Generic;

namespace _02.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                Pizza pizza = new Pizza(pizzaInfo[1]);
                pizzaInfo = Console.ReadLine().Split();
                Dough dough = new Dough(pizzaInfo[1], pizzaInfo[2], double.Parse(pizzaInfo[3]));
                pizza.Dough = dough;

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    pizzaInfo = command.Split();
                    pizza.AddTopping(new Topping(pizzaInfo[1], double.Parse(pizzaInfo[2])));
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
