using System;
using System.Collections.Generic;

namespace _01._ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversed = new Stack<char>(input);

            while (reversed.Count > 0)
            {
                Console.Write(reversed.Pop());
            }
        }
    }
}
