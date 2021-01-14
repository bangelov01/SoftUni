using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbertOfQueries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 1; i <= numbertOfQueries; i++)
            {
                int[] numCommands = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = numCommands[0];

                switch (command)
                {
                    case 1:
                        int numToPush = numCommands[1];
                        numbers.Push(numToPush);
                        break;
                    case 2:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }
                        numbers.Pop();
                        break;
                    case 3:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(numbers.Max());
                        break;
                    case 4:
                        if (numbers.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(numbers.Min());
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
