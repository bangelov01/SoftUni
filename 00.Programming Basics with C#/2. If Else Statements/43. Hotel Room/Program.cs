using System;

namespace _43._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());
            
            double pricePerNightApartment = 0;
            double pricePerNightStudio = 0;

            switch (month)
            {
                case "May":
                case "October":
                    pricePerNightApartment = 65;
                    pricePerNightStudio = 50;
                    break;
                case "June":
                case "September":
                    pricePerNightApartment = 68.70;
                    pricePerNightStudio = 75.20;
                    break;
                case "July":
                case "August":
                    pricePerNightApartment = 77;
                    pricePerNightStudio = 76;
                    break;
            }

            pricePerNightStudio *= nightsCount;
            pricePerNightApartment *= nightsCount;

            if (month == "May"|| month == "October")
            {
                if (nightsCount > 7 && nightsCount < 14)
                {
                    pricePerNightStudio *= 0.95;
                }
                else if (nightsCount > 14)
                {
                    pricePerNightStudio *= 0.70;
                }

            }
            else if (nightsCount > 14 && month == "June"||month == "September")
            {
                pricePerNightStudio *= 0.80;
            }
            if (nightsCount > 14)
            {
                pricePerNightApartment *= 0.90;
            }


            Console.WriteLine($"Apartment: {pricePerNightApartment:f2} lv.");
            Console.WriteLine($"Studio: {pricePerNightStudio:f2} lv.");


        }
    }
}
