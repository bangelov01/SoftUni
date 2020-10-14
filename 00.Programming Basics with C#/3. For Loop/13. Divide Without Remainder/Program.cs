using System;

namespace _13._Divide_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            double countTwo = 0;
            double countThree = 0;
            double countFour = 0;
            double totalNumberCount = 0;

            for (int i = 0; i < n ; i++)
            {
                double num = double.Parse(Console.ReadLine());
                totalNumberCount++;
                if (num % 2 == 0) countTwo++;
                if (num % 3 == 0) countThree++;
                if (num % 4 == 0) countFour++;
            }
            Console.WriteLine($"{countTwo/totalNumberCount*100:f2}%");
            Console.WriteLine($"{countThree/totalNumberCount*100:f2}%");
            Console.WriteLine($"{countFour/totalNumberCount*100:f2}%");
        }
    }
}
