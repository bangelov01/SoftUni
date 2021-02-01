using System;

namespace _24.Fuel_Tank_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFuel = Console.ReadLine();
            double amountFuel = double.Parse(Console.ReadLine());
            string haveCard = Console.ReadLine();

            double priceGasoline = amountFuel * 2.22;
            double priceDiesel = amountFuel * 2.33;
            double priceGas = amountFuel * 0.93;

            if (haveCard == "Yes")
            {
                priceGasoline = amountFuel * 2.04;
                priceDiesel = amountFuel * 2.21;
                priceGas = amountFuel * 0.85;
            }
            if (amountFuel >= 20 && amountFuel <= 25 && typeOfFuel == "Gasoline")
            {
                priceGasoline -= priceGasoline * 8 / 100;
                Console.WriteLine($"{priceGasoline:f2} lv.");
            }
            else if (amountFuel >25 && typeOfFuel == "Gasoline")
            {
                priceGasoline -= priceGasoline * 10 / 100;
                Console.WriteLine($"{priceGasoline:f2} lv.");
            }
            else if (amountFuel < 20 && typeOfFuel == "Gasoline")
            {
                Console.WriteLine($"{priceGasoline:f2} lv.");
            }
            else if (amountFuel >= 20 && amountFuel <= 25 && typeOfFuel == "Diesel")
            {
                priceDiesel -= priceDiesel * 8 / 100;
                Console.WriteLine($"{priceDiesel:f2} lv.");
            }
            else if (amountFuel > 25 && typeOfFuel == "Diesel")
            {
                priceDiesel -= priceDiesel * 10 / 100;
                Console.WriteLine($"{priceDiesel:f2} lv.");
            }
            else if (amountFuel < 20 && typeOfFuel == "Diesel")
            {
                Console.WriteLine($"{priceDiesel:f2} lv.");
            }
            else if (amountFuel >= 20 && amountFuel <= 25 && typeOfFuel == "Gas")
            {
                priceGas -= priceGas * 8 / 100;
                Console.WriteLine($"{priceGas:f2} lv.");
            }
            else if (amountFuel > 25 && typeOfFuel == "Gas")
            {
                priceGas -= priceGas * 10 / 100;
                Console.WriteLine($"{priceGas:f2} lv.");
            }
            else if (amountFuel < 20 && typeOfFuel == "Gas")
            {
                Console.WriteLine($"{priceGas:f2} lv.");
            }

        }
    }
}
