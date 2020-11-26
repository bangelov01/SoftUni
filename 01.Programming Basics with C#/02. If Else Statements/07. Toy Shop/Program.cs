using System;

namespace _07._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            double priceTrip = double.Parse(Console.ReadLine());
            int numberPuzzles = int.Parse(Console.ReadLine());
            int numberTalkingDolls = int.Parse(Console.ReadLine());
            int numberTeddyBears = int.Parse(Console.ReadLine());
            int numberMinions = int.Parse(Console.ReadLine());
            int numberTrucks = int.Parse(Console.ReadLine());

            double pricePuzzle = 2.60;
            int priceDoll = 3;
            double priceTeddyBear = 4.10;
            double priceMinion = 8.20;
            int priceTruck = 2;
            
            int toysAmount = numberPuzzles + numberTalkingDolls + numberTeddyBears + numberMinions + numberTrucks;
            double toysPriceSum = (numberPuzzles * pricePuzzle)
                + (numberTalkingDolls * priceDoll)
                + (numberTeddyBears * priceTeddyBear)
                + (numberMinions * priceMinion) 
                + (numberTrucks * priceTruck);

            

            if (toysAmount >= 50)
            {
                
                double toysPriceSumDisc = toysPriceSum * 0.75;
                double rentPer = (toysPriceSumDisc * 10) / 100;
                double profit = toysPriceSumDisc - rentPer;

                if (priceTrip <= profit)
                {
                    double leftOver = profit - priceTrip;
                    Console.WriteLine($"Yes! {leftOver:f2} lv left.");
                }
                else
                {
                    double neededMoney = priceTrip - profit;
                    Console.WriteLine($"Not enough money! {neededMoney:f2} lv needed.");
                }

            }
            else
            {
                double rent = (toysPriceSum * 10) / 100;
                double profit = toysPriceSum - rent;

                if (priceTrip <= profit)
                {
                    double leftOver = profit - priceTrip;
                    Console.WriteLine($"Yes! {leftOver:f2} lv left.");
                }
                else
                {
                    double neededMoney = priceTrip - profit;
                    Console.WriteLine($"Not enough money! {neededMoney:f2} lv needed.");
                }

            }

        }
    }
}
