using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CommandPattern.Models
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public void IncreasePrice(decimal amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for this product is increased by {amount}");
        }

        public void DecreasePrice(decimal amount)
        {
            if (amount < this.Price)
            {
                this.Price -= amount;
                Console.WriteLine($"The price for this product is decreased by {amount}");
            }
        }

        public override string ToString() => $"Current price for {this.Name} is {this.Price}";
    }
}
