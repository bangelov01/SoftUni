using System;

namespace _24._Movie_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = a1; i <= a2-1; i++)
            {
                char c1 = Convert.ToChar(i);

                for (int j = 1; j <= n-1; j++)
                {
                    for (int k = 1; k <= n/2-1; k++)
                    {
                        int c4 = Convert.ToInt32(c1);
                        int sum = j + k + c4;
                        if (c4 % 2 != 0 && sum % 2 != 0)
                        {
                            Console.WriteLine($"{c1}-{j}{k}{c4}");
                        }
                    }
                }
            }
        }
    }
}
