using System;

namespace _39.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFlower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double priceOfFlowers = 0;

            switch (typeOfFlower)
            {
                case "Roses":
                    priceOfFlowers = 5; break;
                case "Dahlias":
                    priceOfFlowers = 3.80; break;
                case "Tulips":
                    priceOfFlowers = 2.80; break;
                case "Narcissus":
                    priceOfFlowers = 3; break;
                case "Gladiolus":
                    priceOfFlowers = 2.50; break;
            }
            double priceWithoutDisc = priceOfFlowers * numberOfFlowers;
            double percentage = 0;

            switch (typeOfFlower)
            {
                case "Roses":
                    if (numberOfFlowers > 80)
                    {
                        percentage = priceWithoutDisc * 10 / 100;
                    }
                    break;
                case "Tulips":
                    if (numberOfFlowers > 80)
                    {
                        percentage = priceWithoutDisc * 15 / 100;
                    }
                    break;
                case "Dahlias":
                    if (numberOfFlowers > 90)
                    {
                        percentage = priceWithoutDisc * 15 / 100;
                    }
                    break;
                case "Narcissus":
                    if (numberOfFlowers < 120)
                    {
                        percentage = priceWithoutDisc * 15 / 100;
                    }
                    break;
                case "Gladiolus":
                    if (numberOfFlowers < 80)
                    {
                        percentage = priceWithoutDisc * 20 / 100;
                    }break;

            }
            double finalPrice = 0;
            if (typeOfFlower == "Narcissus" || typeOfFlower == "Gladiolus")
            {
                finalPrice = priceWithoutDisc + percentage;
            }
            else
            {
                finalPrice = priceWithoutDisc - percentage;
            }

            if (finalPrice <= budget)
            {
                double difference = budget - finalPrice;
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeOfFlower} and {difference:f2} leva left.");
            }
            else
            {
                double neededSum = finalPrice - budget;
                Console.WriteLine($"Not enough money, you need {neededSum:f2} leva more.");

            }
        }
    }
}
