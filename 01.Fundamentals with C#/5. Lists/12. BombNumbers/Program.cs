using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            int[] bombNumberAndPower = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int bomb = bombNumberAndPower[0];
            int power = bombNumberAndPower[1];

            if (numbers.Contains(bomb))
            {
                int leftPower = power;
                int rightPower = power;

                for (int i = 0; i <= numbers.Count - 1; i++)
                {
                    if (numbers[i] == bomb)
                    {
                        if ((i - power) <= 0)
                        {
                            leftPower = 0 + i;
                        }
                        if ((i + power) > numbers.Count - 1)
                        {
                            rightPower = (numbers.Count - 1) - i;
                        }

                        int count = leftPower + rightPower + 1;
                        int index = i - leftPower;

                        numbers.RemoveRange(index, count);
                    }
                }
            }
            int sum = numbers.Sum();
            Console.WriteLine(sum);
        }
    }
}
