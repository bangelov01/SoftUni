using System;
using System.Linq;

namespace _04.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (int i = values.Length-1; i >= 0; i--)
            {
                Console.Write(values[i] + " ");
            }
        }
    }
}
