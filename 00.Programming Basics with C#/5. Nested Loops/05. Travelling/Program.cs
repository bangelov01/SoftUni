using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double minimalBudget = double.Parse(Console.ReadLine());
                double sumOfAmount = 0;

                while (sumOfAmount < minimalBudget)
                {
                    double savedMoney = double.Parse(Console.ReadLine());
                    sumOfAmount += savedMoney;
                }
                Console.WriteLine($"Going to {destination}!");
            }
        }
    }
}
