using System;
using System.Linq;

namespace _03._CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = word => char.IsUpper(word[0]);

            string[] words = Console.ReadLine().Split($" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)
                .ToArray();

            Console.WriteLine(string.Join($"{Environment.NewLine}", words));
        }
    }
}
