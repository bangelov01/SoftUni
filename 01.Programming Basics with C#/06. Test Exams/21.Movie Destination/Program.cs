using System;

namespace _21.Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());
            double price = 0;

            if (season == "Winter")
            {
                switch (destination)
                {
                    case "Dubai": 
                        price = 45000;
                        price *= days;
                        price *= 0.70;
                        break;
                    case "Sofia":
                        price = 17000;
                        price *= days;
                        double percent = price * 0.25;
                        price += percent;
                        break;
                    case "London":
                        price = 24000;
                        price *= days;
                        break;
                }
            }
            else
            {
                switch (destination)
                {
                    case "Dubai":
                        price = 40000;
                        price *= days;
                        price *= 0.70;
                        break;
                    case "Sofia":
                        price = 12500;
                        price *= days;
                        double percent = price * 0.25;
                        price += percent;
                        break;
                    case "London":
                        price = 20250;
                        price *= days;
                        break;
                }
            }
            if (price <= budget)
            {
                budget -= price;
                Console.WriteLine($"The budget for the movie is enough! We have {budget:f2} leva left!"
);
            }
            else
            {
                price -= budget;
                Console.WriteLine($"The director needs {price:f2} leva more!"
);
            }
        }
    }
}
