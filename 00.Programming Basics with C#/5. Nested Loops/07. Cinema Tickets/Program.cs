using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalStandardTickets = 0;
            int totalStudentTickets = 0;
            int totalKidTickets = 0;
            while (true)
            {
                string movie = Console.ReadLine();
                if (movie == "Finish") break;
                int freeSpots = int.Parse(Console.ReadLine());
                int totalFreeSpots = freeSpots;
                int ticketsForMovie = 0;

                while (freeSpots > 0)
                {
                    string ticket = Console.ReadLine();

                    if (ticket == "End")
                    {
                        break;
                    }

                    switch (ticket)
                    {
                        case "standard": totalStandardTickets++; break;
                        case "kid": totalKidTickets++; break;
                        case "student": totalStudentTickets++; break;
                    }
                    ticketsForMovie++;
                    freeSpots--;
                }

                double capacity = ticketsForMovie * 1.0 / totalFreeSpots * 100;

                Console.WriteLine($"{movie} - {capacity:f2}% full.");
            }

            int totalTickets = totalKidTickets + totalStandardTickets + totalStudentTickets;

            double avgStudent = totalStudentTickets* 1.0 / totalTickets * 100;
            double avgKid = totalKidTickets* 1.0 / totalTickets * 100;
            double avgStandard = totalStandardTickets* 1.0 / totalTickets * 100;

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{avgStudent:f2}% student tickets.");
            Console.WriteLine($"{avgStandard:f2}% standard tickets.");
            Console.WriteLine($"{avgKid:f2}% kids tickets.");
        }
    }
}
