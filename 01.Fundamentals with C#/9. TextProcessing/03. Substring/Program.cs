using System;
using System.Linq;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string toRemove = Console.ReadLine().ToLower();
            string toRemoveFrom = Console.ReadLine();

            while (toRemoveFrom.Contains(toRemove))
            {
                int index = toRemoveFrom.IndexOf(toRemove);
                string result = toRemoveFrom.Remove(index, toRemove.Length);

                toRemoveFrom = result;
            }

            Console.WriteLine(toRemoveFrom);
        }
    }
}
