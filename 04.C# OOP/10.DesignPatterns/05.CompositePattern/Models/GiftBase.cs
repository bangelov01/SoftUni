using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CompositePattern.Models
{
    public abstract class GiftBase
    {
        protected string name;
        protected decimal price;

        protected GiftBase(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract decimal CalculateTotalPrice();
    }
}
