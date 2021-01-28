using System;
using System.Linq;

namespace _06._ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = name => Console.WriteLine(name);

            names.ToList().ForEach(name => print(name));
        }
    }
}
