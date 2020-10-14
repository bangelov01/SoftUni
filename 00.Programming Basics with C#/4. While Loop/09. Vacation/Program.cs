using System;

namespace _09._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int daysCount = 0;
            int spendCount = 0;

            while (availableMoney < neededMoney && spendCount < 5)
            {
                string action = Console.ReadLine();
                double moneySpendOrSave = double.Parse(Console.ReadLine());
                daysCount++;
                if (action == "spend")
                {
                    availableMoney -= moneySpendOrSave;
                    spendCount++;
                    if (availableMoney < 0) availableMoney = 0;
                }
                if (action == "save")
                {
                    availableMoney += moneySpendOrSave;
                    spendCount = 0;
                }
            }
            if (spendCount == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine($"{daysCount}");
            }
            if (availableMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.");
            }
        }
    }
}
