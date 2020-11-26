using System;
using System.Collections.Generic;
using System.Text;

namespace _06._StoreBoxes
{
    class Box
    {
        public Box(int serialNumber, Item item, int itemQuantity, double priceForABox)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            PriceForABox = priceForABox;
        }
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }
    }
}
