using System;

namespace _15.World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string stage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsNum = int.Parse(Console.ReadLine());
            string photo = Console.ReadLine();
            bool above = false;

            double ticketPrice = 0;

            if (stage == "Quarter final")
            {
                switch (ticketType)
                {
                    case "Standard": ticketPrice = 55.50;
                        break;
                    case "Premium": ticketPrice = 105.20;
                        break;
                    case "VIP": ticketPrice = 118.90;
                        break;
                }
            }
            else if (stage == "Semi final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        ticketPrice = 75.88;
                        break;
                    case "Premium":
                        ticketPrice = 125.22;
                        break;
                    case "VIP":
                        ticketPrice = 300.40;
                        break;
                }
            }
            else
            {
                switch (ticketType)
                {
                    case "Standard":
                        ticketPrice = 110.10;
                        break;
                    case "Premium":
                        ticketPrice = 160.66;
                        break;
                    case "VIP":
                        ticketPrice = 400;
                        break;
                }
            }

            double allTicketsPrice = ticketPrice * ticketsNum;

            if (allTicketsPrice > 2500 && allTicketsPrice <= 4000)
            {
                allTicketsPrice *= 0.90;
            }
            else if (allTicketsPrice > 4000)
            {
                allTicketsPrice *= 0.75;
                above = true;
            }

            if (photo == "Y")
            {
                if (above)
                {
                    Console.WriteLine($"{allTicketsPrice:f2}");
                }
                else
                {
                    ticketsNum *= 40;
                    allTicketsPrice += ticketsNum;
                    Console.WriteLine($"{allTicketsPrice:f2}");
                }
            }
            else
            {
                Console.WriteLine($"{allTicketsPrice:f2}");
            }
        }
    }
}
