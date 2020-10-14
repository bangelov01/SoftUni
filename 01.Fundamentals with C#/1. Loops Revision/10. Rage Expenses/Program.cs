using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            double lostGames = double.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double sum = 0;

            for (double i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    sum += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    sum += mousePrice;
                }
                if (i % 6 == 0)
                {
                    sum += keyboardPrice;
                }
                if (i % 12 == 0)
                {
                    sum += displayPrice;
                }
            }

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
