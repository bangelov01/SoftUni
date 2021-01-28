using System;
using System.Linq;

namespace _04._AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> calculate = amount => amount += amount * 0.20m;
            Func<decimal, decimal> round = amount => Math.Round(amount, 2);

            decimal[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(calculate)
                .Select(round)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,prices));
        }
    }
}
