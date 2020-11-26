using System;
using System.Linq;

namespace _04._TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var word in banList)
            {
                string toReplace = new string('*', word.Length);
                string result = text.Replace(word, toReplace);
                text = result;
            }

            Console.WriteLine(text);
        }
    }
}
