using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> products;

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products { get => this.products.AsReadOnly(); }

        public void AddToBag(Product product)
        {
            if (product.Cost > Money)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
                return;
            }

            Console.WriteLine($"{Name} bought {product.Name}");

            Money -= product.Cost;

            products.Add(product);
        }
    }
}
