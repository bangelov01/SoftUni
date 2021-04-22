using _05.CompositePattern.Models;
using System;

namespace _05.CompositePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SingleGift phone = new("IPhone", 1500);
            phone.CalculateTotalPrice();

            CompositeGift toyBox = new("ToyGoodies", 150);
            SingleGift teddyBear = new("Ted", 100);
            SingleGift toyCar = new("Mustang", 50);

            toyBox.Add(teddyBear);
            toyBox.Add(toyCar);

            CompositeGift littleChemistKit = new("LittleChemist", 70);
            SingleGift viles = new("Viles", 30);
            SingleGift chemicalElements = new("Elements", 40);

            littleChemistKit.Add(viles);
            littleChemistKit.Add(chemicalElements);

            toyBox.Add(littleChemistKit);

            Console.WriteLine($"Total price of the ToyBox is: {toyBox.CalculateTotalPrice()}");

        }
    }
}
