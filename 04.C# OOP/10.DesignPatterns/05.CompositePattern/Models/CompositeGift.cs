using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompositePattern.Models
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts = new();
        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            this.gifts = new();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public override decimal CalculateTotalPrice()
        {
            decimal total = 0;

            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (var item in gifts)
            {
                total += item.CalculateTotalPrice();
            }

            return total;
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
    }
}
