using System;
using System.Linq;

namespace _01._ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                char[] inputArr = input.ToCharArray();
                Console.WriteLine($"{input} = {string.Join("", inputArr.Reverse())}");

                input = Console.ReadLine();
            }
        }
    }
}
