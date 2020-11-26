using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04._SimpleEmailValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"^[\w-\.]+\@([\w]+\.)+[a-z]{2,4}$";

            int attempts = 3;

            Console.WriteLine($"Write email for validation!\r\n" +
                $"You have {attempts} attempts!");

            while (attempts > 0)
            {
                string input = Console.ReadLine();

                Match output = Regex.Match(input, regex);

                if (output.Success)
                {
                    Console.WriteLine($"{input} is a valid email!\r\n" +
                        $"Welcome!");
                    Environment.Exit(0);
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"{input} is invalid!\r\n" +
                        $"You have {attempts} left!");
                }
            }

            Console.WriteLine("Banned!");
        }
    }
}
