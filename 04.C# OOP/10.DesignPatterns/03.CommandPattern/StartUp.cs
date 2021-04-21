using _03.CommandPattern.Contracts;
using _03.CommandPattern.Models;
using System;

namespace _03.CommandPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("IPhone", 1500);

            Execute(product, modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 200));
            Execute(product, modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, Enums.PriceAction.Decrease, 100));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
