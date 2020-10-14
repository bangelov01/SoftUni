using System;

namespace _06._Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());
            double amount = 0;
            int countProducts = 0;
            double average = 0;
            double basket = 1.50;
            double wreath = 3.80;
            double chocolateBunny = 7;

            for (int i = 1; i <= clients; i++)
            {
                string type = Console.ReadLine();

                while (type != "Finish")
                {
                    if (type == "basket") amount += basket;
                    if (type == "wreath") amount += wreath;
                    if (type == "chocolate bunny") amount += chocolateBunny;
                    countProducts++;
                    type = Console.ReadLine();
                }
                if (countProducts % 2 ==0)
                {
                    double percent = amount * 0.2;
                    amount -= percent;
                }
                average += amount;
                Console.WriteLine($"You purchased {countProducts} items for {amount:F2} leva.");

                amount = 0;
                countProducts = 0;
            }
            Console.WriteLine($"Average bill per client is: {average/clients:F2} leva.");
        }
    }
}
