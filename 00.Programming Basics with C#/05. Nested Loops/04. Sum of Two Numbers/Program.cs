using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginning = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combination = 0;
            bool flag = false;

            for (int i = beginning; i <= end; i++)
            {
                for (int j = beginning; j <= end; j++)
                {
                    combination++;

                    if (i+j == magicNumber)
                    {
                        flag = true;
                        Console.WriteLine($"Combination N:{combination} ({i} + {j} = {magicNumber})");
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicNumber}");

            }
        }
    }
}
