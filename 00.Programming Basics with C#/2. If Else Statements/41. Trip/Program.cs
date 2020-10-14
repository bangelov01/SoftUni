using System;

namespace _41._Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string vacationPlace = "";
            
            if (budget <= 100)
            {
                destination = "Bulgaria";

                switch (season)
                {
                    case "summer":
                        vacationPlace = "Camp";
                        budget *= 0.30;
                        break;
                    case "winter":
                        vacationPlace = "Hotel";
                        budget *= 0.70;
                        break;

                }
            }
            else if (budget <=1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        vacationPlace = "Camp";
                        budget *= 0.40;
                        break;
                    case "winter":
                        vacationPlace = "Hotel";
                        budget *= 0.80;
                        break;

                }
            }
            else if (budget > 1000)
            {
                destination = "Europe";

                switch (season)
                {
                    case "summer":
                    case "winter":
                        vacationPlace = "Hotel";
                        budget *= 0.90;
                        break;
                }
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{vacationPlace} - {budget:f2}");
        }
    }
}
