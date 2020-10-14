using System;

namespace _09.GreaterThanTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "int":
                    Console.WriteLine(GetMax(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    break;
                case "char":
                    Console.WriteLine(GetMax(char.Parse(Console.ReadLine()), char.Parse(Console.ReadLine())));
                    break;
                case "string":
                    Console.WriteLine(GetMax(Console.ReadLine(), Console.ReadLine()));
                    break;
            }

        }

        static int GetMax(int first, int second)
        {
            int result = first.CompareTo(second);

            if (result > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static char GetMax(char first, char second)
        {
            int result = first.CompareTo(second);

            if (result > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

        static string GetMax(string first, string second)
        {
            int result = first.CompareTo(second);

            if (result > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
