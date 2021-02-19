using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.TriDunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> mainFunc = (a, b) => a.Sum(c => c) >= b;
            Func<Func<string, int, bool>, List<string>, string> finalFunc = (a, b) => b.FirstOrDefault(c => a(c, number));

            string result = finalFunc(mainFunc, names);

            if (result != null)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(string.Empty);
            }

        }
    }
}
