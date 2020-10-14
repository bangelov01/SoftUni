using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Sum(firstNumber, secondNumber);
                    break;
                case "subtract":
                    Subtract(firstNumber, secondNumber);
                    break;
                case "divide":
                    Divide(firstNumber, secondNumber);
                    break;
                case "multiply":
                    Multiply(firstNumber, secondNumber);
                    break;
            }
        }

        static void Sum(int first, int second)
        {
            Console.WriteLine(first + second);
        }
        static void Subtract(int first, int second)
        {
            Console.WriteLine(first - second);
        }
        static void Divide(int first, int second)
        {
            Console.WriteLine(first / second);
        }
        static void Multiply(int first, int second)
        {
            Console.WriteLine(first * second);
        }

    }
}
