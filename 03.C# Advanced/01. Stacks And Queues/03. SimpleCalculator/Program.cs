using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numsAndOperands = Console.ReadLine().Split().Reverse().ToArray();

            Stack<string> numsDigitsStack = new Stack<string>(numsAndOperands);

            while (numsDigitsStack.Count > 1)
            {
                int leftNum = int.Parse(numsDigitsStack.Pop());
                string operand = numsDigitsStack.Pop();
                int rightNum = int.Parse(numsDigitsStack.Pop());

                if (operand == "+")
                {
                    int sum = leftNum + rightNum;
                    numsDigitsStack.Push(sum.ToString());
                }
                else if (operand == "-")
                {
                    int subtract = leftNum - rightNum;
                    numsDigitsStack.Push(subtract.ToString());
                }
            }

            Console.WriteLine(numsDigitsStack.Pop());
        }
    }
}
