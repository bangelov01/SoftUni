using System;

namespace _42.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operand = Console.ReadLine();

            double number = 0;

            switch (operand)
            {
                case "+":
                    number = n1 + n2;
                    break;
                case "-":
                    number = n1 - n2;
                    break;
                case "*":
                    number = n1 * n2;
                    break;
                case "/":
                    number = n1 / n2;
                    break;
                case "%":
                    number = n1 % n2;
                    break;
            }

            string oddOrEven = "";

            if (number%2 == 0)
            {
                oddOrEven = "even";
            }
            else
            {
                oddOrEven = "odd";
            }

            switch (operand)
            {
                case "+":
                case "-":
                case "*":
                    Console.WriteLine($"{n1} {operand} {n2} = {number} - {oddOrEven}");
                    break;
                case "/":
                    if (n2 != 0)
                    {
                        Console.WriteLine($"{n1} / {n2} = {number:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }
                    break;
                case "%":
                    if (n2 != 0)
                    {
                        Console.WriteLine($"{n1} % {n2} = {number}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {n1} by zero");
                    }

                    break;
            }
        }
    }
}
