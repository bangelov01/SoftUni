using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculation(int.Parse(Console.ReadLine()),
                Console.ReadLine(),
                int.Parse(Console.ReadLine())));
        }

        static double Calculation (int firstNum, string op, int secondNumber)
        {
            double result = 0d;
            switch (op)
            {
                case "+":
                    result = firstNum + secondNumber;
                    break;
                case "-":
                    result = firstNum - secondNumber;
                    break;
                case "*":
                    result = firstNum * secondNumber;
                    break;
                case "/":
                    result = firstNum / secondNumber;
                    break;
            }
            return result;
        }
    }
}
