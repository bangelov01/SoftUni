using System;

namespace _03._Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string eggSize = Console.ReadLine();
            string eggColor = Console.ReadLine();
            double numberOfPartions = double.Parse(Console.ReadLine());
            double eggPrice = 0;
            double price = 0;

            if (eggSize == "Large")
            {
                switch (eggColor)
                {
                    case "Red": eggPrice = 16; break;
                    case "Green": eggPrice = 12; break;
                    case "Yellow": eggPrice = 9; break;
                }
            }
            else if (eggSize == "Medium")
            {
                switch (eggColor)
                {
                    case "Red": eggPrice = 13; break;
                    case "Green": eggPrice = 9; break;
                    case "Yellow": eggPrice = 7; break;
                }
            }
            else if (eggSize == "Small")
            {
                switch (eggColor)
                {
                    case "Red": eggPrice = 9; break;
                    case "Green": eggPrice = 8; break;
                    case "Yellow": eggPrice = 5; break;
                }
            }
            price = numberOfPartions * eggPrice;

            double spend = price * 0.35;

            price -= spend;

            Console.WriteLine($"{price:f2} leva.");
        }
    }
}
