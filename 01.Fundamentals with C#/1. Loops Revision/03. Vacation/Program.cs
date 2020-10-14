using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0.00;

            if (groupType == "Students")
            {
                switch (day)
                {
                    case "Friday":
                        price = 8.45;
                        break;
                    case "Saturday":
                        price = 9.80;
                        break;
                    case "Sunday":
                        price = 10.46;
                        break;
                }
                price *= people;
                if (people >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (groupType == "Business")
            {
                switch (day)
                {
                    case "Friday":
                        price = 10.90;
                        break;
                    case "Saturday":
                        price = 15.60;
                        break;
                    case "Sunday":
                        price = 16.00;
                        break;
                }
                if (people >= 100)
                {
                    people -= 10;
                    price *= people;
                }
                else
                {
                    price *= people;
                }
            }
            else if (groupType == "Regular")
            {
                switch (day)
                {
                    case "Friday":
                        price = 15.00;
                        break;
                    case "Saturday":
                        price = 20.00;
                        break;
                    case "Sunday":
                        price = 22.50;
                        break;
                }
                price *= people;
                if (people >= 10 && people <= 20)
                {
                    price *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
