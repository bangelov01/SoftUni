using System;
using System.Linq;

namespace _07._Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> addTitle = t => Console.WriteLine($"Sir {t}");

            names.ToList().ForEach(n => addTitle(n));
        }
    }
}
