using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = string.Empty;

            List<Box> boxes = new List<Box>();

            while ((data = Console.ReadLine()) != "end")
            {
                string[] dataArr = data.Split();

                int serialNumber = int.Parse(dataArr[0]);
                string itemName = dataArr[1];
                int itemQuantity = int.Parse(dataArr[2]);
                double itemPrice = double.Parse(dataArr[3]);
                double priceOfOneBox = itemQuantity * itemPrice;

                Item newItem = new Item(itemName, itemPrice);
                Box newBox = new Box(serialNumber, newItem, itemQuantity, priceOfOneBox);
                boxes.Add(newBox);
            }

            List<Box> sortedBoxes =  boxes.OrderBy(x => x.PriceForABox).Reverse().ToList();

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}\r\n-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}\r\n-- ${box.PriceForABox:f2}");
            }
        }
    }
}
