using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ShoppingSpree
{
    public class Product
    {
        private string name;
        private int cost;

        public Product(string name, int money)
        {
            Name = name;
            Cost = money;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Cost
        {
            get => this.cost;
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                cost = value;
            }
        }
    }
}
