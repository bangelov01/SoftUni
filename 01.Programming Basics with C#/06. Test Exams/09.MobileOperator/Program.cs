using System;

namespace _09._Mobile_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractDuration = Console.ReadLine();
            string contractType = Console.ReadLine();
            string addedOrMobileNet = Console.ReadLine();
            int numberMonthsToPay = int.Parse(Console.ReadLine());

            double monthlyPrice = 0;

            if (contractDuration == "one")
            {
                switch (contractType)
                {
                    case "Small": monthlyPrice = 9.98; break;
                    case "Middle": monthlyPrice = 18.99; break;
                    case "Large": monthlyPrice = 25.98; break;
                    case "ExtraLarge": monthlyPrice = 35.99; break;
                }
            }
            else
            {
                switch (contractType)
                {
                    case "Small": monthlyPrice = 8.58; break;
                    case "Middle": monthlyPrice = 17.09; break;
                    case "Large": monthlyPrice = 23.59; break;
                    case "ExtraLarge": monthlyPrice = 31.79; break;
                }
            }

            if (addedOrMobileNet == "yes")
            {
                if (monthlyPrice <= 10.00)
                {
                    monthlyPrice += 5.50;
                }
                else if (monthlyPrice > 10.00 && monthlyPrice <= 30.00)
                {
                    monthlyPrice += 4.35;
                }
                else if (monthlyPrice > 30.00)
                {
                    monthlyPrice += 3.85;
                }
            }

            double total = monthlyPrice * numberMonthsToPay;

            if (contractDuration == "two")
            {
                total *= 0.9625;
            }

            Console.WriteLine($"{total:f2} lv.");
        }
    }
}
