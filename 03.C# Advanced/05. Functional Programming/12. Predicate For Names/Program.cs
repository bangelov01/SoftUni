using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string,int, bool> condition = (name,nameLength) => name.Length <= nameLength;

            names = names.Where(n => condition(n, nameLength)).ToList();

            Action<List<string>> printer = p =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            };

            printer(names);
        }
    }
}
