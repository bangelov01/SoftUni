using System;

namespace _09.Pipes_in_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine()); //area in litres
            int p1 = int.Parse(Console.ReadLine()); // flow through pipe 1
            int p2 = int.Parse(Console.ReadLine()); // flow through pipe 2
            double h = double.Parse(Console.ReadLine()); //hours worker left

            double p1Flow = p1 * h;
            double p2Flow = p2 * h;
            double wholeFlow = p1Flow + p2Flow;

            if (wholeFlow <= v)
            {
                double pWhole = (wholeFlow / v) * 100;
                double pP1 = (p1Flow / wholeFlow) * 100;
                double pP2 = (p2Flow / wholeFlow) * 100;

                Console.WriteLine($"The pool is {pWhole:f2}% full." +
                    $" Pipe 1: {pP1:f2}%. Pipe 2: {pP2:f2}%.");

            }
            else
            {
                double overflow = wholeFlow - v;
                Console.WriteLine($"For {h:f2} hours the pool " +
                    $"overflows with {overflow:f2} liters.");
            }
        }
    }
}
