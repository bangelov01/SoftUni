using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int apartmentsOnFloor = int.Parse(Console.ReadLine());
            int max = floors;

            for (int i = floors; i > 0; i--)
            {
                for (int j = 0; j < apartmentsOnFloor; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (i == max)
                        {
                            Console.Write($"L{i}{j} ");
                        }
                        else
                        {
                            Console.Write($"O{i}{j} ");
                        }
                    }
                    else
                    {
                        if (i == max)
                        {
                            Console.Write($"L{i}{j} ");
                        }
                        else
                        {
                            Console.Write($"A{i}{j} ");
                        }
                    }
                    if (j == (apartmentsOnFloor - 1))
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
