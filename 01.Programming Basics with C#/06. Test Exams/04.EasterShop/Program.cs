using System;

namespace _04._Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int startEggQuantity = int.Parse(Console.ReadLine());
            string buyOrFill = Console.ReadLine();
            bool isOut = false;
            int boughtEggs = 0;

            while (buyOrFill != "Close")
            {
                int numberBuyOrFill = int.Parse(Console.ReadLine());
                if (buyOrFill == "Buy") 
                {
                    if (numberBuyOrFill > startEggQuantity)
                    {
                        isOut = true;
                        break;
                    }
                    startEggQuantity -= numberBuyOrFill;
                    boughtEggs += numberBuyOrFill;
                }
                if (buyOrFill == "Fill") startEggQuantity += numberBuyOrFill;

                buyOrFill = Console.ReadLine();
            }
            if (isOut)
            {
                Console.WriteLine($"Not enough eggs in store!\r\nYou can buy only {startEggQuantity}.");
            }
            else
            {
                Console.WriteLine($"Store is closed!\r\n{boughtEggs} eggs sold.");
            }
        }
    }
}
