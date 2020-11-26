using System;
using System.Runtime.ConstrainedExecution;

namespace _36.Ski_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfDays = double.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string review = Console.ReadLine();

            double priceForRoom = 0;
            if (typeOfRoom == "room for one person")
            {
                priceForRoom = 18;
            }
            else if (typeOfRoom == "apartment")
            {
                priceForRoom = 25;
            }
            else if (typeOfRoom == "president apartment")
            {
                priceForRoom = 35;
            }

            double priceForStay = priceForRoom * (numberOfDays - 1);
            double percentage = 0;

            if (numberOfDays < 10)
            {
                switch (typeOfRoom)
                {
                    case "room for one person": break;
                    case "apartment":
                        percentage = priceForStay * 30 / 100; break;
                    case "president apartment":
                        percentage = priceForStay * 10 / 100; break;
                }

            }
            else if (numberOfDays >= 10 && numberOfDays <= 15)
            {
                switch (typeOfRoom)
                {
                    case "room for one person": break;
                    case "apartment":
                        percentage = priceForStay * 35 / 100; break;
                    case "president apartment":
                        percentage = priceForStay * 15 / 100; break;
                }
            }
            else
            {
                switch (typeOfRoom)
                {
                    case "room for one person": break;
                    case "apartment":
                        percentage = priceForStay * 50 / 100; break;
                    case "president apartment":
                        percentage = priceForStay * 20 / 100; break;
                }
            }

            double priceForStayWithDiscount = priceForStay - percentage;
            double reviewPercentage = 0;
            double totalPrice = 0;

            if (review == "positive")
            {
                reviewPercentage = priceForStayWithDiscount * 25 / 100;
                totalPrice = priceForStayWithDiscount + reviewPercentage;
            }
            else if (review == "negative")
            {
                reviewPercentage = priceForStayWithDiscount * 10 / 100;
                totalPrice = priceForStayWithDiscount - reviewPercentage;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
