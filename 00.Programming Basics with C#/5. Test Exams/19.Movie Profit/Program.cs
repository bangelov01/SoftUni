using System;

namespace _19.Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());
            double tickets = double.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            double percentCinema = double.Parse(Console.ReadLine());

            double priceTickets = tickets * ticketPrice;
            double amountTickets = days * priceTickets;
            double income = amountTickets * percentCinema / 100;

            amountTickets -= income;
            Console.WriteLine($"The profit from the movie {movie} is {amountTickets:f2} lv.");


        }
    }
}
