using System;

namespace _07._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();
            int count = 0;

            while (true)
            {
                string book = Console.ReadLine();
                count++;
                if (book == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {--count} books.");
                    break;
                }
                if (favouriteBook == book)
                {
                    Console.WriteLine($"You checked {--count} books and found it.");
                    break;
                }
            }
        }
    }
}
