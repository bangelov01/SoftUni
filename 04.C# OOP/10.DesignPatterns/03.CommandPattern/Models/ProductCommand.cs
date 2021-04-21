using _03.CommandPattern.Contracts;
using _03.CommandPattern.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CommandPattern.Models
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly int _amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            _product = product;
            _priceAction = priceAction;
            _amount = amount;
        }
        public void ExecuteAction()
        {
            if (_priceAction == PriceAction.Increase)
            {
                _product.IncreasePrice(_amount);
            }
            else
            {
                _product.DecreasePrice(_amount);
            }
        }
    }
}
